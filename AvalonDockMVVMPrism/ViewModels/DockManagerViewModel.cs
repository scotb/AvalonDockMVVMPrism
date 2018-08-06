using Prism.Logging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AvalonDockMVVMPrism.ViewModels
{
    public class DockManagerViewModel : ViewModelBase
    {
        public ObservableCollection<DockWindowViewModel> Documents { get; private set; } = new ObservableCollection<DockWindowViewModel>();

        public ObservableCollection<object> Anchorables { get; private set; } = new ObservableCollection<object>();

        public DockManagerViewModel(ILoggerFacade logger) : base(logger)
        {
        }

        public void Add(DockWindowViewModel viewModel)
        {
            viewModel.PropertyChanged += ViewModel_PropertyChanged;
            if (!viewModel.IsClosed)
            {
                Documents.Add(viewModel);
            }
        }

        public void AddRange(IEnumerable<DockWindowViewModel> viewModels)
        {
            if (viewModels != null)
            {
                foreach (var vm in viewModels)
                {
                    Add(vm);
                }
            }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is DockWindowViewModel vm && e.PropertyName == nameof(DockWindowViewModel.IsClosed))
            {
                if (!vm.IsClosed)
                {
                    Documents.Add(vm);
                }
                else
                {
                    Documents.Remove(vm);
                }
            }
        }
    }
}