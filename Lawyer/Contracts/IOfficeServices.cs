using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerOffice.Contracts
{
    public delegate void DelegateperOra(string text);

    public interface IOfficeServices
    {
        public void ordinaCibo();
        public void ordinaTraduzione();

        public void ordinaTask();
    }
}
