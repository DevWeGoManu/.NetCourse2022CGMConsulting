using LawyerOffice.Service;
using LawyerOffice.Implementation;
using LawyerOffice.Contracts;
using System.Collections.Generic;
using System.Threading;
using System;
using System.Linq;

namespace LawyerOffice.Utility
{
    public class FoodDelivery
    {
        List<Restaurant> ristoranti { get; set; }

        public FoodDelivery()
        {
            ristoranti = SigData.Init();
        }

        public List<Restaurant> findR(Food food)
        {
            List<Restaurant> ristcibo = new List<Restaurant>();
            foreach (var r in ristoranti)
            {
                foreach (var item in r._dfood)
                {
                    foreach (var item2 in item.Value)
                    {
                        if (item2._nome == food._nome) { 
                            ristcibo.Add(r); 
                        }
                    }
                }
            }
            return ristcibo;
        }

        public Dictionary<FOODTYPE, List<Food>> GetMenu(Restaurant rest)
        {
            return rest.GetMenu();
        }

        public void ritornaL(DateTime time, Food food, DelegateperOra del)
        {
            DateTime oraconsegna = time.AddMinutes(findR(food)[0].time);
            
            del($"L'ordine Preso in carico: {time} Ora prevista consegna: {oraconsegna}");
        }
        
        //ORDINA: 15.21 //messaggio a video cibo preso in carico
        //CONSEGNA PREVISTA // 15.26

        public Food DeliveryOrder(Food food)
        {
            Console.WriteLine("Il cibo sta arrivando..");
            Thread.Sleep(5000);

            var foodr = findR(food)[0].Order(food);
            return foodr;
        }

    }
}
