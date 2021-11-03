using System;

namespace MicroShop.Utility.Common.Snowflake
{
    /// <summary>
    /// 
    /// </summary>
    public class DisposableAction : IDisposable
    {
        private readonly Action _action;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public DisposableAction(Action action)
        {
            if (action == null)
                throw new ArgumentNullException("action");
            _action = action;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _action();
        }
    }

}
