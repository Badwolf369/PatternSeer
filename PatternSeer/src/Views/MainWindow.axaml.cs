using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Platform.Storage;
using PatternSeer.ViewModels;

namespace PatternSeer.Views
{
    /// <summary>
    /// Primary View used when launched as a desktop application.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initialize a new instance of the <c>MainWindow</c> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.Bind(IsFilePickerOpenProperty, new Binding("IsFilePickerOpen")
                { Mode = BindingMode.TwoWay });
            this.Bind(OpenedFileProperty, new Binding("OpenedFile")
                { Mode = BindingMode.TwoWay });
        }

        /// <summary>
        /// Event that is triggered when observable properties in the
        /// ViewModel are updated.
        /// </summary>
        /// <param name="sender">ViewModel that is updated.</param>
        /// <param name="e">Arguments related to the update event.</param>
        public async void OnViewModelUpdate(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(MainViewModel.IsFilePickerOpen):
                    if (IsFilePickerOpen)
                    {
                        var file = await OpenFilePickerAsync();
                        OpenedFile = file;
                        IsFilePickerOpen = false;
                    }
                    break;
            }
        }

        /* #region ViewModel-synced properties */
        public static readonly AvaloniaProperty<bool>
            IsFilePickerOpenProperty = AvaloniaProperty.
            Register<MainWindow, bool>(nameof(IsFilePickerOpen));
        public bool IsFilePickerOpen
        {
            get { return (bool)GetValue(IsFilePickerOpenProperty); }
            set { SetValue(IsFilePickerOpenProperty, value); }
        }
        public static readonly AvaloniaProperty<Uri>
            OpenedFileProperty = AvaloniaProperty.
            Register<MainWindow, Uri>(nameof(OpenedFile));
        public Uri OpenedFile
        {
            get { return (Uri)GetValue(OpenedFileProperty); }
            set { SetValue(OpenedFileProperty, value); }
        }
        /* #endregion ViewModel-synced properties */

        /* #region File Picker */
        /// <summary>
        /// Asynchronously open the system's file picker, allowing only
        /// one PDF file to be picked.
        /// </summary>
        /// <returns></returns>
        public async Task<Uri> OpenFilePickerAsync()
        {
            Console.WriteLine("Opening file selection dialogue");

            var topLevel = TopLevel.GetTopLevel(this);
            var files = await topLevel.StorageProvider.OpenFilePickerAsync(
                new FilePickerOpenOptions
                {
                    Title = "Open cross stitch chart PDF",
                    AllowMultiple = false,
                    FileTypeFilter = new[] { FilePickerFileTypes.Pdf }
                });
            Console.WriteLine("Closing file selection dialogue");

            if (files.Count > 0)
            {
                return files[0].Path;
            }
            else
            {
                return null;
            }
        }
        /* #endregion File Picker*/
    }
}
