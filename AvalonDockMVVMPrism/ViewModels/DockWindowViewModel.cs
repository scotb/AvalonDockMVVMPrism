using Prism.Commands;
using Prism.Logging;

namespace AvalonDockMVVMPrism.ViewModels
{
    /// <summary>
    /// ViewModel class for a document window.
    /// </summary>
    /// <remarks>
    /// This class is not having it's properties properly bound by the MainWindow until it is removed
    /// and added back via the Main Menu options at the top.  Closing the window directly does not
    /// call into the close method, and none of the boolean properties are properly displayed until
    /// the menu options are used to close and open the window.
    /// </remarks>
    public abstract class DockWindowViewModel : ViewModelBase
    {
        private bool canClose;
        private DelegateCommand closeCommand;
        private bool isClosed;
        private string title;

        public DockWindowViewModel(ILoggerFacade logger) : base(logger)
        {
            CanClose = true;
            IsClosed = false;
        }

        public bool CanClose
        {
            get { return canClose; }
            set { SetProperty(ref canClose, value); }
        }

        public DelegateCommand CloseCommand => closeCommand ?? (closeCommand = new DelegateCommand(Close));

        public bool IsClosed
        {
            get { return isClosed; }
            set { SetProperty(ref isClosed, value); }
        }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public void Close()
        {
            IsClosed = true;
        }
    }
}