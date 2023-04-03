using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.MVC.Models
{
    public class ChuckNorris
    {
        
        public string id { get; set; }

        public DateTime created_at { get; set; }
        public string updated_at { get; set; }
        public string value { get; set; }
    }


    
}