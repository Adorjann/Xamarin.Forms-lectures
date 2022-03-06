using FirstMobileApp.DataAccess;
using FirstMobileApp.Services;
using FirstMobileApp.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstMobileApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly INotesRepository _notesRepository;
        private readonly INavigationService _navigationService;

        private ObservableCollection<NoteItemViewModel> _notesSource;
        private NoteItemViewModel _selectedNote;

        public MainViewModel(INotesRepository notesRepository, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _notesRepository = notesRepository;
            AddNoteCommand = new Command(OnAddNoteCommand);
            SelectedNoteChangedCommand = new Command(OnSelectedNoteChangedCommand);
            LoadNotes();
        }

        public ICommand AddNoteCommand { get; }
        public ICommand SelectedNoteChangedCommand { get; }

        public NoteItemViewModel SelectedNote
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

        public ObservableCollection<NoteItemViewModel> NotesSource
        {
            get => _notesSource;
            set
            {
                _notesSource = value;
                OnPropertyChange(nameof(NotesSource));
            }
        }

        public void LoadNotes()
        {
            var notes = _notesRepository.GetAllNotes().Select(n => new NoteItemViewModel(n));
            NotesSource = new ObservableCollection<NoteItemViewModel>(notes);
        }

        private void OnSelectedNoteChangedCommand()
        {
            if (SelectedNote != null)
            {
                _navigationService.NavigateToNoteEditor(SelectedNote.Note);
            }
            SelectedNote = null;
        }

        private void OnAddNoteCommand(object obj)
        {
            _navigationService.NavigatToNewNote();
        }
    }
}