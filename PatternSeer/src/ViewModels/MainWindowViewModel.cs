using System.Diagnostics;
using System.Reactive;
using ReactiveUI;


namespace PatternSeer.ViewModels {
    public class MainWindowViewModel : ReactiveObject {
        private ReactiveCommand<Func<Task<Uri>>, Unit> OpenSystemFilePickerAsync { get; }
        public async Task OnOpenSystemFilePickerAsync(Func<Task<Uri>> PickFileAsync) {
            Uri filePath = await PickFileAsync();
            Debug.WriteLine($"Picked {filePath}");
        }

        private ReactiveCommand<Unit, Unit> Exit { get; }
        private void OnExit() {
            Debug.WriteLine("Goodbye ):");
            Environment.Exit(0);
        }

        public MainWindowViewModel() {
            Exit = ReactiveCommand.Create(OnExit);
            OpenSystemFilePickerAsync = ReactiveCommand.CreateFromTask<Func<Task<Uri>>>(OnOpenSystemFilePickerAsync);
        }
    }
}