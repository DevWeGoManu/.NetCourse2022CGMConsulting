using System;
using System.Collections.Generic;
namespace AreaGeografica.Models
{ 
    public class Continents
    {
        public int id { set; get; }
        public string nameContinent { get; set; }
        public List<Country> countries { get; set; }

    }
    public class Country
    {
        public Country() { }
        public int id { set; get; }
        public string nameCountry { set; get; }
        public virtual List<Cities>? cities { set; get; }

    }
    public class Cities
    {
        public int id { set; get; }
        public string cities { get; set; }
        public int numeroAbitanti { set; get; }
        public int numeroPositivi { set; get; }
        public string ColorStateCities { set; get; }
 
        public string ColoreCities()
        {
            if (numeroPositivi >= 500000)
                ColorStateCities = "RedState";
            else if (numeroPositivi > 10000 && numeroPositivi < 500000)
                ColorStateCities = "YellowState";
            else if (numeroPositivi <= 10000)
                ColorStateCities = "WhiteState";
            return ColorStateCities;
        }

    }
  
}
