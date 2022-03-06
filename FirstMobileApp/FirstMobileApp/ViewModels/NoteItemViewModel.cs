using FirstMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstMobileApp.ViewModels
{
    public class NoteItemViewModel : BaseViewModel
    {
        private string _title;
        private string _description;

        public NoteItemViewModel(Note note)
        {
            Note = note;
            _title = note.Title;
            _description = note.Description;
        }

        public Note Note { get; }

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