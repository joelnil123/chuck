using chuck.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace chuck.Mocks
{
   public class ApiServiceMock
    {
        public async Task<Jokes> GetRandom()
        {
            await Task.Run(() => { });

            return new Jokes()
            {

             value = "asd"
                };

        }
    }
}
