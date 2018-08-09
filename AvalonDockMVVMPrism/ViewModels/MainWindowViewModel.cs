using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Logging;
using System.Collections.Generic;

namespace AvalonDockMVVMPrism.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IUnityContainer container;

        public DelegateCommand NewDocumentCommand { get; private set; }

        public DockManagerViewModel DockManagerViewModel { get; private set; }

        public MenuViewModel MenuViewModel { get; private set; }

        public MainWindowViewModel(ILoggerFacade logger, IUnityContainer container) : base(logger)
        {
            this.container = container;

            DockManagerViewModel = container.Resolve<DockManagerViewModel>();
            MenuViewModel = container.Resolve<MenuViewModel>();

            for (int i = 0; i < 2; i++)
            {
                var doc = container.Resolve<SampleDockWindowViewModel>();
                DockManagerViewModel.Add(doc);
                doc.Title = $"Sample {i}";
                doc.CanClose = true;
                doc.IsClosed = false;
            }
            MenuViewModel.AddRange(DockManagerViewModel.Documents);
        }
    }
}