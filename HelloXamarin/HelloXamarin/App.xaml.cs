using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HelloXamarin.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HelloXamarin
{
    public partial class App : Application
    {
        private static NoteDatabase mDatabase;

        public App()
        {
            InitializeComponent();

            NotesPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            MainPage = new NavigationPage(new NotesPage());
        }

        public static NoteDatabase Database
        {
            get
            {
                if (mDatabase == null)
                {
                    mDatabase = new NoteDatabase(Path.Combine(NotesPath, "notes.db3"));
                }
                return mDatabase;
            }
        }

        /// <summary>
        /// Path of the notes folder.
        /// </summary>
        /// <remarks>
        /// In this implementation, <see cref="NotesPath"/> is an alias for 
        /// <see cref="Environment.GetFolderPath(Environment.SpecialFolder)"/>.
        /// </remarks>
        public static string NotesPath { get; private set; }

        /// <summary>
        /// Gets full path of the note file.
        /// </summary>
        /// <param name="noteName">File name of the note, with extension.</param>
        /// <returns>
        /// A random file name if <paramref name="noteName"/> is null, empty or whitespace only,
        /// a full file name in all other cases.
        /// </returns>
        public static string GetNoteFileName(string noteName) => Path.Combine(
            NotesPath,
            string.IsNullOrWhiteSpace(noteName) ? Path.GetRandomFileName() : noteName);
    }
}
