using System.Diagnostics;
using System.Reactive;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using ReactiveUI;


namespace PatternSeer.ViewModels {
    public class MainWindowViewModel : ReactiveObject {
        private ReactiveCommand<Unit, Unit> Exit { get; }
        private void OnExit() {
            Debug.WriteLine("Goodbye ):");
            Environment.Exit(0);
        }

        private ReactiveCommand<Unit, Unit> OpenAsyncFilePicker { get; }
        private async Task OnOpenAsyncFilePicker() {
            Debug.WriteLine("Opening file selection dialogue");
            if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop ||
                desktop.MainWindow?.StorageProvider is not { } provider)
                throw new NullReferenceException("Missing StorageProvider instance.");

            var files = await provider.OpenFilePickerAsync(
                new FilePickerOpenOptions() {
                    Title = "Open Cross Stitch PDF chart",
                    AllowMultiple = false,
                    FileTypeFilter = new[] {FilePickerFileTypes.Pdf}
            });
            Debug.WriteLine($"Selected {files[0].Path}");
        }

        public MainWindowViewModel() {
            Exit = ReactiveCommand.Create(OnExit);
            OpenAsyncFilePicker = ReactiveCommand.CreateFromTask(OnOpenAsyncFilePicker);
        }
    }
}