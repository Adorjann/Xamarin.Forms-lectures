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
        public ICommand SaveNoteCommand { get; set; }

        public NoteViewModel(Action action)
        {
            _action = action;
            SaveNoteCommand = new Command(OnSaveNoteCommand);
        }

        public NoteViewModel(Note note)
        {
            Title = note.Title;
            Description = note.Description;
            SaveNoteCommand = new Command(OnSaveNoteCommand);
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