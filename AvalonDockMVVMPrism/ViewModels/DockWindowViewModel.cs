using Prism.Commands;
using Prism.Logging;

namespace AvalonDockMVVMPrism.ViewModels
{
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