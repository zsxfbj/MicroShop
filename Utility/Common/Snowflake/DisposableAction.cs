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
            _action = action ?? throw new ArgumentNullException("action");
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _action();
        }
    }

}
