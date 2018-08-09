# AvalonDockMVVMPrism
Avalon Dock MVVM Prism is based on work by Martin Kramer (https://github.com/8/AvalonDockMVVM)

This project is an attempt to understand and duplicate Martin's code using WPF, Prism and the Unity Container.

There is an issue with my implementation that I can't seem to resolve.  Namely, the DockWindowViewModel's properties are not being bound with the intial window creation.  If you use the menu options to close and then open a document, it's properties are recognized and the View matches the ViewModel state.

As an example, set the CanClose value in MainWindowViewModel.cs line 30 to false.  At first run, the windows are still closable.  Once you use the menu items to hide the closed window and then show it, you will see that the ability to close the window is now gone.

If anyone has an idea on what I am doing wrong, I appreciate any help.  The orginal project works exactly as expected, so it's something I am doing (or not doing). 