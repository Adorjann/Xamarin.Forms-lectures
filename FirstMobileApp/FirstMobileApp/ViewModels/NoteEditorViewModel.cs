using FirstMobileApp.DataAccess;
using FirstMobileApp.Models;
using FirstMobileApp.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstMobileApp.ViewModels
{
    public class NoteEditorViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly INotesRepository _notesRepository;

        private string _title;
        private string _description;
        private Guid _noteId;

        public NoteEditorViewModel(INotesRepository notesRepository, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _notesRepository = notesRepository;

            IsNewNote = true;
            SaveNoteCommand = new Command(OnSaveNoteCommand);
            DeleteNoteCommand = new Command(OnDeleteNoteCommand);
        }

        public ICommand SaveNoteCommand { get; set; }

        public ICommand DeleteNoteCommand { get; set; }

        public bool IsNewNote { get; set; }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChange(nameof(Title));
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChange(nameof(Description));
            }
        }

        internal void LoadNote(Note note)
        {
            IsNewNote = false;
            _noteId = note.Id;
            Title = note.Title;
            Description = note.Description;
        }

        private void OnDeleteNoteCommand(object obj)
        {
            _notesRepository.DeleteNote(_noteId);
            _navigationService.GoBack();
        }

        private void OnSaveNoteCommand()
        {
            var note = new Note(Title, Description);
            _notesRepository.AddNote(note);
            _navigationService.GoBack();
        }
    }
}