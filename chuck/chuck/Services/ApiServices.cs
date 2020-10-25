using chuck.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace chuck.Services
{
    public class ApiServices : IApiServices
    {
        public SearchViewModel mySearchViewMOdel;
        public async Task<Jokes> GetRandomJoke(string catagori)
        {
            var data = await get("https://api.chucknorris.io/jokes/random?category=" + catagori);
            return JsonConvert.DeserializeObject<Jokes>(data);
        }

        private async Task<string> get(string url)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "";
        }

        public async Task<List<string>> GetAllCatagories()
        {
            var data = await getCatagori("https://api.chucknorris.io/jokes/categories");
            var AllCatagories = JsonConvert.DeserializeObject<List<string>>(data);

            return AllCatagories;
        }

        private async Task<string> getCatagori(string url)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return "";
        }

        public async Task<Search> GetSearch(string SearchString)
        {
            var data = await GetSearchfromapi("https://api.chucknorris.io/jokes/search?query=" + SearchString);
            return JsonConvert.DeserializeObject<Search>(data);
        }

        private async Task<string> GetSearchfromapi(string url)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return "";

        }
    }
}


