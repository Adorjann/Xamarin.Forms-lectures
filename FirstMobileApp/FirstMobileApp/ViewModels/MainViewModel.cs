using FirstMobileApp.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstMobileApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<NoteViewModel> _notesSource;

        public ICommand AddNoteCommand { get; }

        public ObservableCollection<NoteViewModel> NotesSource
        {
            get => _notesSource;
            set
            {
                _notesSource = value;
                OnPropertyChange(nameof(NotesSource));
            }
        }

        public MainViewModel()
        {
            AddNoteCommand = new Command(OnAddNoteCommand);
            LoadNotes();
        }

        private void LoadNotes()
        {
            var notes = App.NotesRepository.GetAllNotes().Select(n => new NoteViewModel(n));
            NotesSource = new ObservableCollection<NoteViewModel>(notes);
        }

        private void OnAddNoteCommand(object obj)
        {
            Application.Current
                .MainPage
                .Navigation
                .PushModalAsync(new NoteView { BindingContext = new NoteViewModel(LoadNotes) });
        }
    }
}