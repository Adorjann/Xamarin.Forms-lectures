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
        private NoteViewModel _selectedNote;

        public ICommand AddNoteCommand { get; }
        public ICommand SelectedNoteChangedCommand { get; }

        public NoteViewModel SelectedNote
        {
            get
            {
                return _selectedNote;
            }
            set
            {
                _selectedNote = value;
                OnPropertyChange(nameof(SelectedNote));
            }
        }

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
            SelectedNoteChangedCommand = new Command(OnSelectedNoteChangedCommand);
            LoadNotes();
        }

        private void LoadNotes()
        {
            var notes = App.NotesRepository.GetAllNotes().Select(n => new NoteViewModel(n, LoadNotes));
            NotesSource = new ObservableCollection<NoteViewModel>(notes);
        }

        private void OnSelectedNoteChangedCommand()
        {
            if (SelectedNote != null)
            {
                Application.Current
                    .MainPage
                    .Navigation
                    .PushModalAsync(new NoteView { BindingContext = SelectedNote });
            }
            SelectedNote = null;
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