using System;
using System.Collections.Generic;
using System.Text;

namespace chuck.Services
{
    public class Jokes
    {
        public List<string> categories { get; set; }
        public string created_at { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public string value { get; set; }
        
        public bool IsFavoJoke { get; set; } = false;
    }
}
