using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using PatternSeer.ViewModels;


namespace PatternSeer.Views {
    public partial class MainWindow : Window {
        public MainWindow() {
            MainWindowViewModel vm = new MainWindowViewModel();
            vm.OpenSystemFilePicker += OpenSystemFilePickerAsync;
            DataContext = vm;

            InitializeComponent();
        }

        private async void OpenSystemFilePickerAsync(Object sender, Uri FilePath) {
            Console.WriteLine("Opening file selection dialogue");

            var topLevel = TopLevel.GetTopLevel(this);
            var files = await topLevel.StorageProvider.OpenFilePickerAsync(
                new FilePickerOpenOptions {
                    Title = "Open cross stitch chart PDF",
                    AllowMultiple = false,
                    FileTypeFilter = new[] {FilePickerFileTypes.Pdf}
            });

            if (files.Count > 0) {
                FilePath = files[0].Path;
            } else {
                FilePath = null;
            }
            Console.WriteLine("Closing file selection dialogue");
        }
    }
}