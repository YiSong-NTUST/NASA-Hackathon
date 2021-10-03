using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NASA_Hackathon.Models
{
    public class Level1Model
    {
        public enum Gender { male, female };

        public int age { get; set; }
        public Gender gender { get; set; }
        public int vaccinDoses { get; set; }
        public string vaccineBrand { get; set; }
        public DateTime date { get; set; }

        public IEnumerable<SelectListItem> brandList { get; set; }

        public string location { get; set; }
        public IEnumerable<SelectListItem> locationList { get; set; }
    }
}
