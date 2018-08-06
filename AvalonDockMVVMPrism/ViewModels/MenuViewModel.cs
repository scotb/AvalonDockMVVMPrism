using Microsoft.Practices.Unity;
using Prism.Logging;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AvalonDockMVVMPrism.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private readonly MenuItemViewModel viewMenuItemViewModel;
        private readonly IUnityContainer container;

        public ObservableCollection<MenuItemViewModel> Items { get; private set; } = new ObservableCollection<MenuItemViewModel>();

        public MenuViewModel(ILoggerFacade logger, IUnityContainer container) : base(logger)
        {
            this.container = container;
            viewMenuItemViewModel = container.Resolve<MenuItemViewModel>();
            viewMenuItemViewModel.Header = "Views";
        }

        private void Add(MenuItemViewModel viewModel)
        {
            Items.Add(viewMenuItemViewModel);
        }

        public void AddRange(IEnumerable<DockWindowViewModel> viewModels)
        {
            if (viewModels != null)
            {
                foreach (var viewModel in viewModels)
                {
                    viewMenuItemViewModel.Children.Add(GetMenuItemViewModel(viewModel));
                }
                Add(viewMenuItemViewModel);
            }
        }

        private MenuItemViewModel GetMenuItemViewModel(DockWindowViewModel dockWindowViewModel)
        {
            var menuItemViewModel = container.Resolve<MenuItemViewModel>();
            menuItemViewModel.IsCheckable = true;
            menuItemViewModel.Header = dockWindowViewModel.Title;
            menuItemViewModel.IsChecked = !dockWindowViewModel.IsClosed;

            dockWindowViewModel.PropertyChanged += (o, e) =>
            {
                if (e.PropertyName == nameof(DockWindowViewModel.IsClosed))
                {
                    menuItemViewModel.IsChecked = !dockWindowViewModel.IsClosed;
                }
            };
            menuItemViewModel.PropertyChanged += (o, e) =>
            {
                if (e.PropertyName == nameof(MenuItemViewModel.IsChecked))
                {
                    dockWindowViewModel.IsClosed = !menuItemViewModel.IsChecked;
                }
            };
            return menuItemViewModel;
        }
    }
}