using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LawyerOffice.Contracts;
using LawyerOffice.Implementation;


namespace LawyerOffice.Service
{
    internal class German : ITranslator
    {
        public string getTranslator()
        {
            return "Tedesco";
        }
      
    }
}
