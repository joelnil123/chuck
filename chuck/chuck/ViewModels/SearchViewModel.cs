using chuck.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace chuck.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        public ObservableCollection<Jokes> AllSearchedJokesList { get; set; } = new ObservableCollection<Jokes>();
        public string NEwSearchString { get; set; }

        IApiServices apiService;
   
        // asd = new Image
        //{
        //    Source = ImageSource.FromResource("chuck.images.FavStar.png")
        //};
        public SearchViewModel()
        {
            apiService = DependencyService.Get<IApiServices>();
        }
        public async Task<Search> GetSearchresult()
        {
            AllSearchedJokesList.Clear();
            var JokesFromSearch = await apiService.GetSearch(NEwSearchString);
            AllSearchedJokesList = new ObservableCollection<Jokes>(JokesFromSearch.SearchList);

            foreach (var item in AllSearchedJokesList)
            {
                if (CatagoriViewMmodel.FavoriteJokes.Exists(a => a == item.id))
                {
                 //fixa inotifypropertychanged till en bool
                 // gör den 2 way binding så att den kan sättas/läsas i söksidan/visa skämt sidan
                // så att checkboxen gå att ända där istället (byt bilderna till en interaktiv checkbox)
                    item.icon_url = "Favstar.png";
                    item.IsFavoJoke = true;
                }
                else
                {
                    item.icon_url = "NotFavStar.png";
                    item.IsFavoJoke = false;
                }
            }
            return JokesFromSearch;
        }
    }
}


