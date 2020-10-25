using chuck.Services;
using chuck.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace chuck
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage  
    {
        public CatagoriViewMmodel myCatagorieViewModel = new CatagoriViewMmodel();
        public SearchViewModel _searchViewModel;
        public SearchPage()
        {
            InitializeComponent();
            BindingContext = _searchViewModel = new SearchViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            favList.ItemsSource = CatagoriViewMmodel.favJokes;
        }

        private async void Search_button3(object sender, EventArgs e)
        {
            _searchViewModel.NEwSearchString = SearchText.Text;
            await _searchViewModel.GetSearchresult();

            jokes2.ItemsSource = _searchViewModel.AllSearchedJokesList;
            favList.ItemsSource = CatagoriViewMmodel.favJokes;
        }
    }
}