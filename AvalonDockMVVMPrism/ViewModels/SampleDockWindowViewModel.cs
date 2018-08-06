using Prism.Logging;

namespace AvalonDockMVVMPrism.ViewModels
{
    public class SampleDockWindowViewModel : DockWindowViewModel
    {
        public SampleDockWindowViewModel(ILoggerFacade logger) : base(logger)
        {
        }
    }
}