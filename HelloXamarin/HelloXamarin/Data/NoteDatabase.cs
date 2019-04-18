using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using HelloXamarin.Models;

namespace HelloXamarin.Data
{
    /// <summary>
    /// Represents the notes database.
    /// </summary>
    public class NoteDatabase
    {
        private readonly SQLiteAsyncConnection mDatabaseConnection;

        /// <summary>
        /// Opens a connection to the specified database.
        /// </summary>
        /// <param name="dbPath">Path of database.</param>
        public NoteDatabase(string dbPath)
        {
            mDatabaseConnection = new SQLiteAsyncConnection(dbPath);
            // Creates the notes table if it doesn't exist
            mDatabaseConnection.CreateTableAsync<Note>().Wait();
        }

        /// <summary>
        /// Gets all the notes in the database.
        /// </summary>
        public Task<List<Note>> GetNotesAsync() => mDatabaseConnection.Table<Note>().ToListAsync();
        // Equals to SELECT * FROM notes

        /// <summary>
        /// Gets the specified note.
        /// </summary>
        /// <param name="id">Note identifier.</param>
        public Task<Note> GetNoteAsync(int id) =>
        // Equivalent to SELECT * FROM notes WHERE id = ?
            mDatabaseConnection.Table<Note>().Where(i => i.ID == id).FirstOrDefaultAsync();

        /// <summary>
        /// Updates the database with the specified note.
        /// </summary>
        /// <param name="note"></param>
        /// <remarks>
        /// If the note exists, the existing record is updated. If it does not, a new record is added.
        /// </remarks>
        public Task<int> SaveNoteAsync(Note note) =>
        // If note exists, equals to UPDATE notes SET ... WHERE id = ?
        // If it does not, equals to INSERT INTO notes (...) VALUES (...?) 
            note.ID != 0 ? mDatabaseConnection.UpdateAsync(note) : mDatabaseConnection.InsertAsync(note);

        /// <summary>
        /// Deletes the specified note from the database.
        /// </summary>
        /// <param name="note"></param>
        public Task<int> DeleteNoteAsync(Note note) => mDatabaseConnection.DeleteAsync(note);
        // Equal to DELETE FROM Notes WHERE id = ?
    }
}
