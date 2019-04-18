using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HelloXamarin.Models;

namespace HelloXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            // Populates the list view with the content of the notes DB
            NoteListView.ItemsSource = await App.Database.GetNotesAsync();
        }

        /// <summary>
        /// Creates a new note.
        /// </summary>
        async private void AddNoteItem_Clicked(object sender, EventArgs e)
        {
            // Adds a NoteEntryPage the navigation stack, and sets
            // a new instance of Note as its context
            await Navigation.PushAsync(new NoteEntryPage()
            {
                BindingContext = new Note()
            });
        }

        /// <summary>
        /// Selects a note and loads the page for editing it.
        /// </summary>
        async private void NoteListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                // Adds a NoteEntryPage to the navigation stack, and
                // sets the selected Note as its context
                await Navigation.PushAsync(new NoteEntryPage()
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }
    }
}