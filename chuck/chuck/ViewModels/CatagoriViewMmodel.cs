using chuck.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace chuck.Services
{
   public class CatagoriViewMmodel : BaseViewModel
    {
        //listor för hantering/skriva ut favorit skämt och alla skämt som hämtas från apiet
        public ObservableCollection<Catagori> allCatagories = new ObservableCollection<Catagori>();
        public static ObservableCollection<Jokes> favJokes = new ObservableCollection<Jokes>();
        public static List<string> FavoriteJokes = new List<string>();

        //lägg alting som har med jokes att göra i korrekt vymodell
        public Jokes jokesObject;

        IApiServices apiService;
      
        public CatagoriViewMmodel()
        {
            apiService = DependencyService.Get<IApiServices>();
        }

        string catagori = string.Empty;
        public string Catagori
        {
            get { return catagori; }
            set { SetProperty(ref catagori, value); }
        }

        string joke = string.Empty;
        public string Joke
        {
            get { return joke; }
            set { SetProperty(ref joke, value); }
        }

        public async Task loadCatagories()
        {
            var catagori = await apiService.GetAllCatagories();
            foreach(var item in catagori)
            {
                Catagori myCatagories = new Catagori
                {
                    CatagorieName = item.ToString()
                };
                allCatagories.Add(myCatagories);
            }     
        }

        public async Task<Jokes> GetJokeWIthCatagorie()
        {
            var JokesFromSearch = await apiService.GetRandomJoke(Catagori);
            jokesObject = JokesFromSearch;
            Joke = jokesObject.value;
            return JokesFromSearch;
        }
        //fytta till rätt vymodel
        public bool EditeFavList(bool AdToFavYesOrNo)
        {
            if (AdToFavYesOrNo)
            {
                if (FavoriteJokes.Contains(jokesObject.id))    
                    return false;
                
                    FavoriteJokes.Add(jokesObject.id);
                    favJokes.Add(jokesObject);

                    return true;
            }
            FavoriteJokes.Remove(jokesObject.id);
            favJokes.Remove(jokesObject);

            return false;
        }
    }
}
