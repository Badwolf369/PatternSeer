using System.Diagnostics;
using System.Reactive;
using ReactiveUI;


namespace PatternSeer.ViewModels {
    public class MainWindowViewModel : ReactiveObject {
        public EventHandler<Uri> OpenSystemFilePicker;
        public ReactiveCommand<Unit, Unit> OpenFilePicker { get; }
        public void OnOpenFilePicker() {
            Uri FilePath = null;
            OpenSystemFilePicker?.Invoke(this, FilePath);
            Console.WriteLine($"Picked {FilePath}");
        }

        private ReactiveCommand<Unit, Unit> Exit { get; }
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