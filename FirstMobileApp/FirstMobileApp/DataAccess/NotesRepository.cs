using FirstMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstMobileApp.DataAccess
{
    public class NotesRepository
    {

        private List<Note> _notes = new List<Note>();

        public NotesRepository()
        {
            _notes.Add(new Note("Title", "Description"));
            _notes.Add(new Note("Some Title", "some description"));
            _notes.Add(new Note("Tajtl Buraz", "Ovde neke reci samo da bi smo nabacali neke reci kako bi mogli testirati aplikaciju"));
        }

        public void AddNote(Note note)
        {
            _notes.Add(note);
        }
        public void DeleteNote(Guid id)
        {
            _notes = _notes.Where(note => note.Id != id).ToList();

        }
        public IEnumerable<Note> GetAllNotes()
        {
            return new List<Note>(_notes);
        }

    }
}
