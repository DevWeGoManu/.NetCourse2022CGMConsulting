using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LawyerOffice.Contracts;
using LawyerOffice.Implementation;

namespace LawyerOffice.Service
{
    internal class English : ITranslator
    {
        public string getTranslator()
        {
            return "Inglese";
        }
    }
}
