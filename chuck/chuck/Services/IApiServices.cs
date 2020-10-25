using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace chuck.Services
{
    public interface IApiServices
    {
        Task<Jokes> GetRandomJoke(string catagori);

        Task<List<string>> GetAllCatagories();

        Task<Search> GetSearch(string searchString);
    }
}
