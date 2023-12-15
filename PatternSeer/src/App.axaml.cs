using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using PatternSeer.Views;
using PatternSeer.ViewModels;


namespace PatternSeer {
    /// <summary>
    /// Main wrapper for an Avalonia app.
    /// </summary>
    public partial class App : Application {
        /// <summary>
        /// Initializes the Avalonia app.
        /// </summary>
        public override void Initialize() {
            AvaloniaXamlLoader.Load(this);
        }

        /// <summary>
        /// Runs after the initial creation of the Avalonia app.
        /// </summary>
        public override void OnFrameworkInitializationCompleted() {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
                MainWindowViewModel vm = new MainWindowViewModel();
                MainWindow window = new MainWindow() {
                    DataContext = vm
                };
                desktop.MainWindow = window;
                vm.OpenSystemFilePicker += window.OpenSystemFilePickerAsync;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}