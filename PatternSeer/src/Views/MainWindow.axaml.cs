using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;


namespace PatternSeer.Views {
    public partial class MainWindow : Window {
        public MainWindow() {
            // DataContext = new MainWindowViewModel();
            InitializeComponent();
        }
        // private async void OpenFile(object sender, RoutedEventArgs args) {
        //     var topLevel = TopLevel.GetTopLevel(this);

        //     var file = await topLevel.StorageProvider.
        //         OpenFilePickerAsync(new FilePickerOpenOptions {
        //             Title = "Open a Cross Stitch PDF Chart",
        //             AllowMultiple = false,
        //             FileTypeFilter = new[] {FilePickerFileTypes.Pdf}
        //     });
        // }
    }
}