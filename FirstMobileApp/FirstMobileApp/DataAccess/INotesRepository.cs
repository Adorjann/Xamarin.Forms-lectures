using FirstMobileApp.Models;
using System;
using System.Collections.Generic;

namespace FirstMobileApp.DataAccess
{
    public interface INotesRepository
    {
        void AddNote(Note note);
        void DeleteNote(Guid id);
        IEnumerable<Note> GetAllNotes();
    }
}