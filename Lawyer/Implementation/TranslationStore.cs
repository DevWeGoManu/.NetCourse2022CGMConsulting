using LawyerOffice.Service;
using LawyerOffice.Contracts;
using System;

namespace LawyerOffice.Implementation
{
    public abstract class TranslationStore
    {     
        public abstract ITranslator CreateTranslator();
        public void ManageTranslator()
        {
            var translator = CreateTranslator();
            System.Console.WriteLine($"Traddoto da {translator.getTranslator()}");
        }
        public void Traduci(string parola)
        {
            if (parola == "hello" || parola == "hi")
                Console.Write("ciao");
            else if (parola == "hallo")
                Console.Write("Ciao");
            else
                throw new Exception("errore nel tradurre..");
        }


    }
}
