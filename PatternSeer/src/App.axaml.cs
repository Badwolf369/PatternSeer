using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using PatternSeer.Views;
using PatternSeer.ViewModels;


namespace PatternSeer {
    public partial class App : Application {
        public override void Initialize() {
            AvaloniaXamlLoader.Load(this);
        }

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