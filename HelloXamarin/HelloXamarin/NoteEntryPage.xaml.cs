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
            // Saves note in the database
            var note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            await App.Database.SaveNoteAsync(note);

            // Removes current page from the navigation stack
            await Navigation.PopAsync();
        }

        async private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            // Deletes note from the database
            var note = (Note)BindingContext;
            await App.Database.DeleteNoteAsync(note);

            // Removes current page from the navigation stack
            await Navigation.PopAsync();
        }

        private void NoteTitleEntry_Completed(object sender, EventArgs e)
        {

        }

        private void NoteTitleEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Enables Save button if title is nonempty
            SaveButton.IsEnabled = !string.IsNullOrWhiteSpace((sender as Entry)?.Text);
        }
    }
}