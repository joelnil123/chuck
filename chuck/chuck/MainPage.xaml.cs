using chuck.Services;
using chuck.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace chuck
{
    public partial class MainPage : ContentPage
    {
        public CatagoriViewMmodel CatagoriViewMmodel;
        public MainPage()
        {
            InitializeComponent();

            BindingContext = CatagoriViewMmodel = new CatagoriViewMmodel();
            _ = CatagoriViewMmodel.loadCatagories();
            CatagorieListWiev.ItemsSource = CatagoriViewMmodel.allCatagories;
        }

        private async void GetJokeFromCatagorie(object sender, EventArgs e)
        {
            var ButtonText = (sender as Button);
            CatagoriViewMmodel.Catagori = ButtonText.Text;

            var joke = await CatagoriViewMmodel.GetJokeWIthCatagorie();
            await Navigation.PushAsync(new JokesPage(joke));
        }

        private async void search_button(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new SearchPage());
        }

    }
}
