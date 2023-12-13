using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Platform.Storage;


namespace PatternSeer.Views {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private async Task<Uri> SystemFilePickerAsync() {
            Debug.WriteLine("Opening file selection dialogue");

            var topLevel = TopLevel.GetTopLevel(this);

            var files = await topLevel.StorageProvider.OpenFilePickerAsync(
                new FilePickerOpenOptions {
                    Title = "Open cross stitch chart PDF",
                    AllowMultiple = false,
                    FileTypeFilter = new[] {FilePickerFileTypes.Pdf}
            });

            return files[0].Path;
        }
    }
}