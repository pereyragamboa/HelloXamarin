using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HelloXamarin.Models;

namespace HelloXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NoteEntryPage : ContentPage
	{
		public NoteEntryPage ()
		{
			InitializeComponent ();
		}

        async private void SaveButton_Clicked(object sender, EventArgs e)
        {
            // Saves note in the file system
            var note = (Note)BindingContext;
            File.WriteAllText(App.GetNoteFileName(note.Name), note.Content);

            // Removes current page from the navigation stack
            await Navigation.PopAsync();
        }

        async private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            var noteFileName = App.GetNoteFileName(note.Name);

            // If the file exists, deletes it from the file system
            if (File.Exists(noteFileName))
            {
                File.Delete(noteFileName);
            }

            // Removes current page from the navigation stack
            await Navigation.PopAsync();
        }
    }
}