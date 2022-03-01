using FirstMobileApp.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstMobileApp.ViewModels
{
    public class NoteViewModel : BaseViewModel
    {
        private string _title;
        private string _description;
        private readonly Action _action;
        private Guid _noteId;

        public bool IsNewNote { get; }
        public ICommand SaveNoteCommand { get; set; }

        public ICommand DeleteNoteCommand { get; set; }

        public NoteViewModel(Action action)
        {
            _action = action;
            IsNewNote = true;
            SaveNoteCommand = new Command(OnSaveNoteCommand);
            DeleteNoteCommand = new Command(OnDeleteNoteCommand);
        }

        public NoteViewModel(Note note, Action action) : this(action)
        {
            _noteId = note.Id;
            IsNewNote = false;
            Title = note.Title;
            Description = note.Description;
        }

        private void OnDeleteNoteCommand(object obj)
        {
            App.NotesRepository.DeleteNote(_noteId);
            App.Current.MainPage.Navigation.PopModalAsync();

            _action?.Invoke();
        }

        private void OnSaveNoteCommand()
        {
            var note = new Note(Title, Description);
            App.NotesRepository.AddNote(note);
            Application.Current
                .MainPage
                .Navigation
                .PopModalAsync();

            _action?.Invoke();
        }

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
    }
}