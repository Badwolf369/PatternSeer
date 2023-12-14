using Avalonia.Controls;
using Avalonia.Platform.Storage;


namespace PatternSeer.Views {
    /// <summary>
    /// 
    /// </summary>
    public partial class MainWindow : Window {
        /// <summary>
        /// 
        /// </summary>
        public MainWindow() {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="exitCallback"></param>
        public async void OpenSystemFilePickerAsync(Object sender, Action<Uri> exitCallback) {
            Console.WriteLine("Opening file selection dialogue");

            var topLevel = TopLevel.GetTopLevel(this);
            var files = await topLevel.StorageProvider.OpenFilePickerAsync(
                new FilePickerOpenOptions {
                    Title = "Open cross stitch chart PDF",
                    AllowMultiple = false,
                    FileTypeFilter = new[] {FilePickerFileTypes.Pdf}
            });
            Console.WriteLine("Closing file selection dialogue");

            if (files.Count > 0) {
                exitCallback(files[0].Path);
            } else {
                exitCallback(null);
            }
        }
    }
}
