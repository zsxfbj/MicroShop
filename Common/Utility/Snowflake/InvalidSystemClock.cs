using System;

namespace MicroShop.Common.Utility.Snowflake
{
    /// <summary>
    /// 
    /// </summary>
    public class InvalidSystemClock : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public InvalidSystemClock(string message) : base(message) { }
    }

}
