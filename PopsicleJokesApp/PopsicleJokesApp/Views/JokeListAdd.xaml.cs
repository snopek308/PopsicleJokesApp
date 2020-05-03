using PopsicleJokesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PopsicleJokesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JokeListAdd : ContentPage
    {
        public JokeListAdd()
        {
            InitializeComponent();
        }

        async void JokeSave(object sender, EventArgs e)
        {
            var jokeItem = (JokeItem)BindingContext;
            await App.Database.SaveItemAsync(jokeItem);
            await Navigation.PopAsync();
        }

        async void JokeCancel(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}