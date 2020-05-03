using PopsicleJokesApp.Data;
using PopsicleJokesApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PopsicleJokesApp
{
    public partial class App : Application
    {
        static PopsicleJokeItemDatabase database;
        public App()
        {
            InitializeComponent();

            var nav = new NavigationPage(new JokeListView());
            nav.BarBackgroundColor = (Color)App.Current.Resources["NavyBlue"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
        }

        public static PopsicleJokeItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new PopsicleJokeItemDatabase();
                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
