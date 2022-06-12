using LawyerOffice.Contracts;
using LawyerOffice;
using LawyerOffice.Implementation;
using System;

namespace LawyerOffice.Implementation
{
    public  class Factory
    {
        /// La factory può generare piu tipi di oggetti
        public  TranslationStore CreateTranslationStore(string translationType,string word)
        {
            TranslationStore traduttori = null;

            if (translationType.Equals("English", StringComparison.OrdinalIgnoreCase))
            {
                traduttori = new EnglishOffice();
                traduttori.Traduci(word);
            }

            else if (translationType.Equals("German", StringComparison.OrdinalIgnoreCase))
            {
                traduttori = new GermanOffice();
                traduttori.Traduci(word);
            }
            else
            {
                throw new Exception("Invalid translator type");
            }

            return traduttori;
        }

        
    }
}
