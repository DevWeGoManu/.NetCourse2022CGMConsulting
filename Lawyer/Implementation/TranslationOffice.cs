using LawyerOffice.Contracts;
using LawyerOffice.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerOffice.Implementation
{
    internal class TranslationOffice
    {
        public void testoTradotto(Factory factory, string lingua, string parola)
        {
                //Console.WriteLine("Scegli \"german\" | \"english\" come lingua");
                try
                {
                    TranslationStore traduttori = factory.CreateTranslationStore(lingua, parola);
                    Console.Write(" - ");
                    traduttori.ManageTranslator();
                }
                catch (Exception e)
                {
                    Console.WriteLine(" - " + e.Message);
                }
            Console.WriteLine("ecco il tuo testo tradotto.");
            //System.Console.ReadKey();
        }
    }

    public class EnglishOffice : TranslationStore
    {
        public override ITranslator CreateTranslator()
        {
            return new English();
        }
    }
    public class GermanOffice : TranslationStore
    {
        public override ITranslator CreateTranslator()
        {
            return new German();
        }
    }
}