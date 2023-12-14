using System.Reactive;
using ReactiveUI;


namespace PatternSeer.ViewModels {
    public class MainWindowViewModel : ReactiveObject {
        private Uri LoadedFile;
        public event EventHandler<Action<Uri>> OpenSystemFilePicker;
        private SemaphoreSlim callbackSignal;
        private ReactiveCommand<Unit,Unit> OpenFile { get; }
        private async Task OnOpenFile() {
            await OpenFilePicker();
             if (LoadedFile is not null) {
                Console.WriteLine($"Opened {LoadedFile}");
            } else {
                Console.WriteLine("No file was opened");
            }
        }
        private async Task OpenFilePicker() {
            OpenSystemFilePicker?.Invoke(this, CloseFilePicker);
            callbackSignal = new SemaphoreSlim(0, 1);
            await callbackSignal.WaitAsync();
        }
        private void CloseFilePicker(Uri filePath) {
            LoadedFile = filePath;
            callbackSignal.Release();
        }

        private ReactiveCommand<Unit,Unit> Exit { get; }
        private void OnExit() {
            Console.WriteLine("Goodbye ):");
            Environment.Exit(0);
        }

        public MainWindowViewModel() {
            Exit = ReactiveCommand.Create(OnExit);
            OpenFile = ReactiveCommand.CreateFromTask(OnOpenFile);
        }
    }
}
