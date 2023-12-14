using System.Reactive;
using ReactiveUI;


namespace PatternSeer.ViewModels {
    /// <summary>
    /// Primary ViewModel associated with the View <c>MainView</c>
    /// </summary>
    public class MainWindowViewModel : ReactiveObject {
        /// <summary>
        /// 
        /// </summary>
        private Uri LoadedFile;
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<Action<Uri>> OpenSystemFilePicker;
        /// <summary>
        /// 
        /// </summary>
        private SemaphoreSlim callbackSignal;

        /// <summary>
        /// 
        /// </summary>
        private ReactiveCommand<Unit,Unit> OpenFile { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task OnOpenFile() {
            await OpenFilePicker();
             if (LoadedFile is not null) {
                Console.WriteLine($"Opened {LoadedFile}");
            } else {
                Console.WriteLine("No file was opened");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task OpenFilePicker() {
            OpenSystemFilePicker?.Invoke(this, CloseFilePicker);
            callbackSignal = new SemaphoreSlim(0, 1);
            await callbackSignal.WaitAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        private void CloseFilePicker(Uri filePath) {
            LoadedFile = filePath;
            callbackSignal.Release();
        }

        /// <summary>
        /// 
        /// </summary>
        private ReactiveCommand<Unit,Unit> Exit { get; }
        /// <summary>
        /// 
        /// </summary>
        private void OnExit() {
            Console.WriteLine("Goodbye ):");
            Environment.Exit(0);
        }

        /// <summary>
        /// 
        /// </summary>
        public MainWindowViewModel() {
            Exit = ReactiveCommand.Create(OnExit);
            OpenFile = ReactiveCommand.CreateFromTask(OnOpenFile);
        }
    }
}
