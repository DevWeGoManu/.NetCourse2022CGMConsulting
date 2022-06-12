using LawyerOffice.Contracts;
using LawyerOffice.Service;
using LawyerOffice.Utility;
using System;

namespace LawyerOffice.Implementation
{
    public class OfficeManager
    {
        public DeliveryOffice _deliveryOffice { get; set; }
        public FoodDelivery foodDelivery = new FoodDelivery();
        public TaskDelivery taskDelivery = new TaskDelivery();
        DelegateperOra deleg;

        public OfficeManager()
        {
            //_translationOffice = new TranslationOffice();
            _deliveryOffice = new DeliveryOffice();
            deleg = FeedBack;
        }

        public void askFood(Food food)
        {
            var restlist = foodDelivery.findR(food);
            Console.WriteLine("Scegli il ristorante tra questi:");
            foreach (var r in restlist)
            {
                Console.WriteLine(r._Name);
            }
            var random = new Random();
            int index = random.Next(restlist.Count);
            Menu(restlist[index]);
        }

        public void Menu(Restaurant rest)
        {
            Console.WriteLine("Hai scelto il:"+rest._Name);
            var menurist = rest.GetMenu();
            foreach (var diz in menurist.Values)
            {
                foreach (var list in diz)
                {
                    Console.Write(list._nome + ", ");
                }
                Console.Write("\n");
            }
        }
        public void ordinaCibo(Food food, DateTime date)
        {
            foodDelivery.ritornaL(date, food, deleg);
            var foodi = _deliveryOffice.ordinaCibo(food);
            Console.WriteLine(foodi._nome);
        }

        public void FeedBack(string message)
        {
            Console.WriteLine(message);
        }

        public void ordinaTask(TASKTYPE taskt, DateTime date)
        {
            taskDelivery.ritornaT(date, taskt, deleg);
            var taski = _deliveryOffice.ordinaTask(taskt);
            Console.WriteLine(taski);
        }
        public void ordinaTraduzione(string lingua, string parola)
        {
            #region Translator
            Factory factory = new Factory();
            TranslationOffice testoTradotto = new TranslationOffice();
            testoTradotto.testoTradotto(factory, lingua, parola);
            #endregion Translator
        }
    }
}
