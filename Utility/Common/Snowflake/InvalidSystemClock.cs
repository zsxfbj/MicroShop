using System;

namespace MicroShop.Utility.Common.Snowflake
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
