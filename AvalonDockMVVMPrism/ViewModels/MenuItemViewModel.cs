using Prism.Logging;
using System.Collections.Generic;
using System.Windows.Input;

namespace AvalonDockMVVMPrism.ViewModels
{
    public class MenuItemViewModel : ViewModelBase
    {
        private bool isChecked;

        /// <summary>
        /// Creates a new instance of the MenuItemViewModelClass.
        /// </summary>
        /// <param name="logger"></param>
        public MenuItemViewModel(ILoggerFacade logger) : base(logger)
        {
        }

        /// <summary>
        /// List of sub MenuItems contained by this MenuItem.
        /// </summary>
        public List<MenuItemViewModel> Children { get; private set; } = new List<MenuItemViewModel>();

        /// <summary>
        /// The command to execute when the menu item is selected.
        /// </summary>
        public ICommand Command { get; private set; }

        /// <summary>
        /// Header displayed to the user when the menu is expanded.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// True if the item is checkable, false otherwise.
        /// </summary>
        public bool IsCheckable { get; set; }

        /// <summary>
        /// True if the MenuItem is checked, false otherwise.
        /// </summary>
        public bool IsChecked
        {
            get { return isChecked; }
            set { SetProperty(ref isChecked, value); }
        }
    }
}