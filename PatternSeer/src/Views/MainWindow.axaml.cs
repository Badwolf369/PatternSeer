using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
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
            this.Bind(OpenedPatternProperty, new Binding("OpenedPattern")
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
                        var file = await ViewUtils.OpenFilePickerAsync(
                            TopLevel.GetTopLevel(this)
                        );
                        OpenedPattern = file;
                        IsFilePickerOpen = false;
                    }
                    break;
            }
        }

        /* #region ViewModel-synced properties */
        /// <summary>
        /// Avalonia property to sync IsFilePickerOpen with the view
        /// </summary>
        public static readonly AvaloniaProperty<bool>
            IsFilePickerOpenProperty = AvaloniaProperty.
            Register<MainWindow, bool>(nameof(IsFilePickerOpen));
        public bool IsFilePickerOpen
        {
            get { return (bool)GetValue(IsFilePickerOpenProperty); }
            set { SetValue(IsFilePickerOpenProperty, value); }
        }
        /// <summary>
        /// Avalonia property to sync OpenedFile with the view
        /// </summary>
        public static readonly AvaloniaProperty<Uri>
            OpenedPatternProperty = AvaloniaProperty.
            Register<MainWindow, Uri>(nameof(OpenedPattern));
        /// <summary>
        /// Path to the currently opened file
        /// </summary>
        public Uri OpenedPattern
        {
            get { return (Uri)GetValue(OpenedPatternProperty); }
            set { SetValue(OpenedPatternProperty, value); }
        }
        /* #endregion ViewModel-synced properties */
    }
}
