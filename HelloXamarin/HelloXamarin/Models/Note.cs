using System;
using SQLite;

namespace HelloXamarin.Models
{
    /// <summary>
    /// Represents a note.
    /// </summary>
    public class Note
    {
        public Note() => Date = DateTime.UtcNow;

        /// <summary>
        /// Identifier of the note.
        /// </summary>
        [PrimaryKey, AutoIncrement] public int ID { get; set; }
        // Sets this property as the primary key for the notes tables

        /// <summary>
        /// Title of the note.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Content of the note itself.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Creation date of the note.
        /// </summary>
        public DateTime Date { get; set; }

        public override string ToString() => $"{Date.ToString()}: {Content}";
    }
}
