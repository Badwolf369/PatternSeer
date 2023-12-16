using System.Reactive;
using ReactiveUI;


namespace PatternSeer.ViewModels {
    /// <summary>
    /// Primary ViewModel associated with the View <c>MainView</c>
    /// </summary>
    public class MainWindowViewModel : ReactiveObject {
        /// <summary>
        /// Path to the currently loaded PDF file.
        /// </summary>
        private Uri LoadedFile;
        /// <summary>
        /// Event handler that signals the View to open the system's
        /// file picker.
        /// </summary>
        /// TODO: Move this event handler and the callbackSignal to a utils file
        public event EventHandler<Action<Uri>> OpenSystemFilePicker;
        /// <summary>
        /// Signal used for when an asynchronous event is called, such as
        /// <c>OpenSystemfilePicker</c>, that lets the current thread wait 
        /// asyncronously the event's callback is triggered.
        /// </summary>
        private SemaphoreSlim callbackSignal;

        /// <summary>
        /// Command trigger that is run when the user signals they want a
        /// new file to be opened.
        /// </summary>
        private ReactiveCommand<Unit,Unit> OpenFile { get; }
        /// <summary>
        /// Command associated with the OpenFile command trigger. Triggers
        /// the View to open the System's file picker.
        /// </summary>
        private async Task OnOpenFile() {
            await OpenFilePicker();
             if (LoadedFile is not null) {
                Console.WriteLine($"Opened {LoadedFile}");
            } else {
                Console.WriteLine("No file was opened");
            }
        }
        /// <summary>
        /// Trigger the View to open the System's file picker, then wait
        /// for the associated callback to run.
        /// </summary>
        private async Task OpenFilePicker() {
            OpenSystemFilePicker?.Invoke(this, CloseFilePicker);
            callbackSignal = new SemaphoreSlim(0, 1);
            await callbackSignal.WaitAsync();
        }
        /// <summary>
        /// Callback associated with OpenFilePicker. Meant to be triggered
        /// when the user is finished picking the file.
        /// </summary>
        /// <param name="filePath">Path to the file picked by the user</param>
        private void CloseFilePicker(Uri filePath) {
            LoadedFile = filePath;
            callbackSignal.Release();
        }

        /// <summary>
        /// Command trigger that activates when the User signals they
        /// want to exit the application.
        /// </summary>
        private ReactiveCommand<Unit,Unit> Exit { get; }
        /// <summary>
        /// Command associated with the Exit trigger. Prints a message and
        /// then exits the program.
        /// </summary>
        private void OnExit() {
            Console.WriteLine("Goodbye ):");
            Environment.Exit(0);
        }

        /// <summary>
        /// Initializes a new instance of the <c>MainWindowViewModel</c>
        /// class
        /// </summary>
        public MainWindowViewModel() {
            Exit = ReactiveCommand.Create(OnExit);
            OpenFile = ReactiveCommand.CreateFromTask(OnOpenFile);
        }
    }
}
