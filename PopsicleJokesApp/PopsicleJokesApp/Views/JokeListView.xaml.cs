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
    public partial class JokeListView : ContentPage
    {
        public JokeListView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new JokeListView
            {
                BindingContext = new JokeItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new JokeListView
                {
                    BindingContext = e.SelectedItem as JokeItem
                });
            }
        }
    }
}