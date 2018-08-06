using Prism.Logging;
using Prism.Mvvm;
using System;

namespace AvalonDockMVVMPrism.ViewModels
{
    /// <summary>
    /// Base class for all ViewModels contained in the application.
    /// </summary>
    public abstract class ViewModelBase : BindableBase, IDisposable
    {
        protected ILoggerFacade logger;

        /// <summary>
        /// Creates a new instance of the ViewModelBase class.
        /// </summary>
        /// <param name="logger"></param>
        public ViewModelBase(ILoggerFacade logger)
        {
            this.logger = logger;
        }

        #region IDisposable Members

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
#if !DEBUG
            GC.SuppressFinalize(this);
#endif
        }

        /// <summary>
        /// Child classes should override this method to perform
        /// clean-up logic, such as removing event handlers.
        /// <param name="disposing">
        /// Boolean parameter disposing indicates whether the method was invoked from the
        /// IDisposable.Dispose implementation or from the finalizer
        /// </param>
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
        }

#if DEBUG

        /// <summary>
        /// Useful for ensuring that ViewModel objects are properly garbage collected.
        /// </summary>
        ~ViewModelBase()
        {
            string msg = $"{GetType().Name} ({GetHashCode()}) Finalized";
            logger.Log(msg, Category.Debug, Priority.None);
        }

#endif

        #endregion IDisposable Members
    }
}