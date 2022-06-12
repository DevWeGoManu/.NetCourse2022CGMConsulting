using LawyerOffice.Implementation;
using LawyerOffice.Contracts;
using LawyerOffice.Service;
using System.Collections.Generic;
using System;
using LawyerOffice.Utility;

namespace LawyerOffice.Service
{
    public class Restaurant
    {
        public string _Name { get; set; }
        public RestaurantType _restaurantType { get; set; }
        //List<Food> _food { get; set; }
        public Dictionary<FOODTYPE, List<Food>> _dfood { get; set; }
        public int time;

        public Restaurant(string name, 
            RestaurantType resttype, Dictionary<FOODTYPE, List<Food>> dfood)
        {
            time = 5;
            _Name = name;
            _restaurantType = resttype;
            _dfood = dfood;
        }
        public Dictionary<FOODTYPE,List<Food>> GetMenu()
        {
            return _dfood;
        }
        public Food Order(Food food)
        {
            return food;
        }
    }

    public class Food
    {
        public string _nome { get; set; }
        //public FOODTYPE _foodtype { get; set; }
        public Food(string nome)
        {
            _nome = nome;
        }
    }
}
