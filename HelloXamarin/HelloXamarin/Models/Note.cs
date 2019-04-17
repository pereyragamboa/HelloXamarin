using System;

namespace HelloXamarin.Models
{
    /// <summary>
    /// Represents a note.
    /// </summary>
    public class Note
    {
        public Note() => Date = DateTime.UtcNow;

        /// <summary>
        /// Name of the note.
        /// </summary>
        public string Name { get; set; }

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
