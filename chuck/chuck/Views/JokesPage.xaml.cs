using chuck.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace chuck.Views
{
    public partial class JokesPage : ContentPage
    {
        public CatagoriViewMmodel _catagorieVIeModel;
        public JokesPage(Jokes jokes)
        {
            InitializeComponent();
            _catagorieVIeModel = new CatagoriViewMmodel
            {
                Catagori = jokes.categories.FirstOrDefault(),
                Joke = jokes.value,
                jokesObject = jokes,
            };
    
            BindingContext = _catagorieVIeModel;
        }

        void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            //samma här en metod i vymodelen som retunerar tru/false till e.value
            if (e.Value)
            {
                _catagorieVIeModel.EditeFavList(e.Value);
            }
            else
            {
                _catagorieVIeModel.EditeFavList(e.Value);
            }
        }

        private async void NewButton_Clicked(object sender, EventArgs e)
        {
           var NewJoke = await _catagorieVIeModel.GetJokeWIthCatagorie();
            //ändra och lägg i jokes vymodelen istället för att sköta logic här
            //en metod som retunerar true/false till box.ischecked istället
            if(CatagoriViewMmodel.FavoriteJokes.Contains(NewJoke.id))
            {
                Box.IsChecked = true;
            }
            else
            {
                Box.IsChecked = false;
            }
        }
    }
}