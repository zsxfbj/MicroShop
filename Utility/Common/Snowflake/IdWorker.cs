using System;

namespace MicroShop.Utility.Common.Snowflake
{
    /** Copyright 2010-2012 Twitter, Inc.*/

    /**
     * An object that generates IDs.
     * This is broken into a separate class in case
     * we ever want to support multiple worker threads
     * per process
     */
    public class IdWorker
    {
        /// <summary>
        /// 
        /// </summary>
        public const long Twepoch = 1288834974657L;

        const int WorkerIdBits = 5;
        const int DatacenterIdBits = 5;
        const int SequenceBits = 12;
        const long MaxWorkerId = -1L ^ (-1L << WorkerIdBits);
        const long MaxDatacenterId = -1L ^ (-1L << DatacenterIdBits);

        private const int WorkerIdShift = SequenceBits;
        private const int DatacenterIdShift = SequenceBits + WorkerIdBits;

        /// <summary>
        /// 时间戳位移数
        /// </summary>
        public const int TimestampLeftShift = SequenceBits + WorkerIdBits + DatacenterIdBits;
        private const long SequenceMask = -1L ^ (-1L << SequenceBits);
        private long _lastTimestamp = -1L;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="workerId"></param>
        /// <param name="datacenterId"></param>
        /// <param name="sequence"></param>
        public IdWorker(long workerId, long datacenterId, long sequence = 0L)
        {
            WorkerId = workerId;
            DatacenterId = datacenterId;
            Sequence = sequence;

            // sanity check for workerId
            if (workerId > MaxWorkerId || workerId < 0)
            {
                throw new ArgumentException(string.Format("worker Id can't be greater than {0} or less than 0", MaxWorkerId));
            }

            if (datacenterId > MaxDatacenterId || datacenterId < 0)
            {
                throw new ArgumentException(string.Format("datacenter Id can't be greater than {0} or less than 0", MaxDatacenterId));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public long WorkerId { get; protected set; }

        /// <summary>
        /// 数据中心编号
        /// </summary>
        public long DatacenterId { get; protected set; }

        /// <summary>
        /// 序号值
        /// </summary>
        public long Sequence { get; internal set; } = 0L;

        readonly object _lock = new Object();

        /// <summary>
        /// 获取新的序号
        /// </summary>
        /// <returns></returns>
        public virtual long NextId()
        {
            lock (_lock)
            {
                var timestamp = TimeGen();

                if (timestamp < _lastTimestamp)
                {
                    throw new InvalidSystemClock(string.Format(
                        "Clock moved backwards.  Refusing to generate id for {0} milliseconds", _lastTimestamp - timestamp));
                }

                if (_lastTimestamp == timestamp)
                {
                    Sequence = (Sequence + 1) & SequenceMask;
                    if (Sequence == 0)
                    {
                        timestamp = TilNextMillis(_lastTimestamp);
                    }
                }
                else
                {
                    Sequence = 0;
                }

                _lastTimestamp = timestamp;
                var id = ((timestamp - Twepoch) << TimestampLeftShift) |
                         (DatacenterId << DatacenterIdShift) |
                         (WorkerId << WorkerIdShift) | Sequence;

                return id;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lastTimestamp"></param>
        /// <returns></returns>
        protected virtual long TilNextMillis(long lastTimestamp)
        {
            var timestamp = TimeGen();
            while (timestamp <= lastTimestamp)
            {
                timestamp = TimeGen();
            }
            return timestamp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual long TimeGen()
        {
            return System.CurrentTimeMillis();
        }
    }

}
