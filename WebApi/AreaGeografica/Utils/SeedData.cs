using System;
using System.Collections.Generic;
using AreaGeografica.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AreaGeografica.Persistance.Configuration;

namespace AreaGeografica.Utils
{
    public static class SeedData
    {
        public static async Task SeedDatabase(DatabaseCxt dbCtx)
        {            
            Clear(dbCtx.Cities);
            Clear(dbCtx.Country);
            Clear(dbCtx.Continents);
            Random positiviRandomici = new Random();

            List<Cities> italianCities = new List<Cities>()
            {
                new Cities(){cities = "Milano" , numeroAbitanti = 1500000 , numeroPositivi = positiviRandomici.Next(1500000) },
                new Cities(){cities = "Verona" , numeroAbitanti = 120000  , numeroPositivi = positiviRandomici.Next(120000)  },
                new Cities(){cities = "Livorno", numeroAbitanti = 849201  , numeroPositivi = positiviRandomici.Next(849201)  }
            };
            
            List<Cities> germanCities = new List<Cities>()
            {
                new Cities(){cities = "Berlino"    , numeroAbitanti = 3721459, numeroPositivi = positiviRandomici.Next(3721459)},
                new Cities(){cities = "Dresda"     , numeroAbitanti = 556780 , numeroPositivi = positiviRandomici.Next(556780)},
                new Cities(){cities = "Fracoforte" , numeroAbitanti = 763380 , numeroPositivi = positiviRandomici.Next(763380)}
            };

            germanCities[0].ColoreCities();
            germanCities[1].ColoreCities();
            germanCities[2].ColoreCities();
 

            italianCities[0].ColoreCities();
            italianCities[1].ColoreCities();
            italianCities[2].ColoreCities();

            
            List<Country> country = new List<Country>()
            {
                new Country(){nameCountry = "Italy", cities = italianCities },
                new Country(){nameCountry = "Germany", cities = germanCities}
            };

            Continents continents = new Continents()
            {
                nameContinent = "EuropeWest",
                countries = country
            };

            dbCtx.Continents.Add(continents);
            try
            {
                await dbCtx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            if (dbSet.Any())
            {
                dbSet.RemoveRange(dbSet.ToList());
            }
        }
    }
}
