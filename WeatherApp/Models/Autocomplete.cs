using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    /// <summary>
    /// Contains the definiton required for implementing the auto complete
    /// </summary>
    public class LocationAutoComplete
    {
        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        public Country Country { get; set; }
        public AdministrativeArea AdministrativeArea { get; set; }
    }

    public class Country
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
    }

    public class AdministrativeArea
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
    }
}
