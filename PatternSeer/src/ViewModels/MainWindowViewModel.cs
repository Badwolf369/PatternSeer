using System.Diagnostics;
using System.Reactive;
using Avalonia.Platform.Storage;
using ReactiveUI;


namespace PatternSeer.ViewModels {
    public class MainWindowViewModel : ReactiveObject {
        public event EventHandler<Action<Uri>> OpenSystemFilePicker;
        private ReactiveCommand<Unit,Unit> OpenFilePicker { get; }
        private void OnOpenFilePicker() {
            OpenSystemFilePicker?.Invoke(this, OnCloseFileDialogue);
        }
        private void OnCloseFileDialogue(Uri filePath) {
            Console.WriteLine($"Picked {filePath}");
        }

        private ReactiveCommand<Unit,Unit> Exit { get; }
        private void OnExit() {
            Debug.WriteLine("Goodbye ):");
            Environment.Exit(0);
        }

        public MainWindowViewModel() {
            Exit = ReactiveCommand.Create(OnExit);
            OpenFilePicker = ReactiveCommand.Create(OnOpenFilePicker);
        }
    }
}