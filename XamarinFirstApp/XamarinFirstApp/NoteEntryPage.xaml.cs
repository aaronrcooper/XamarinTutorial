using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using XamarinFirstApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFirstApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.FileName))
            {
                var fileName = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(fileName, note.Text);
            }
            else
            {
                File.WriteAllText(note.FileName, note.Text);
            }

            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (File.Exists(note.FileName))
            {
                File.Delete(note.FileName);
            }

            await Navigation.PopAsync();
        }
    }
}