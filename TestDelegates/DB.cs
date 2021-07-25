using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDelegates
{
    public class DB
    {
      private List<Note> Notes = new List<Note>();

        private DB() { LoadData(); }

        private static DB _instance;

        public static DB GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DB();
            }
            return _instance;
        }

        private void LoadData()
        {

            for (int i = 0; i < 10; i++)
            {
                var note = new Note
                {
                    Id= Guid.NewGuid().ToString(),
                    Date = DateTime.Now.Date,
                    Text = $"ljfsljfksljfsjfksdfksfklskflsflsfsdl sfkldsfkjsdklfjsd {i}"
                };


                Notes.Add(note);
            }
        }
      public void InsertNewNote(Note note)
        {
            Notes.Add(note);
        }

        public bool DeleteNote(Note note)
        {
            var result = Notes.Remove(note);
            return result;
        }

        public List<Note> GetNotes()
        {
            return Notes;
        }

        public Note GetNoteByID(string id)
        {
            var n = Notes.Where(x=>x.Id == id)
                .FirstOrDefault();
            return n;
        }
    }

    public class Note
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }

        public string Text { get; set; }
    }
}
