using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruits.api.Models
{
    //Unique data model that represents and item in the app
    //In this case it represents a recruit
    public class Recruit
    {
        //Unique ID for recruit
        public int Id {get; set;}
        public string Name {get; set;}
        public string University { get; set; }
        public string Major { get; set; }
        public double Gpa { get; set; }
        public string Skills { get; set; }
    }
}