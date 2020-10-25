using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace chuck.Services
{
    public class Search
    {
        [JsonProperty ("result")]
        public List<Jokes> SearchList { get; set; }


        //får id kolla villka som är med på favorit
    }
}
