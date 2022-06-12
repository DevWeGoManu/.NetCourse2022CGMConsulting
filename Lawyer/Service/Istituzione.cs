using LawyerOffice.Implementation;
using System.Collections.Generic;

namespace LawyerOffice.Service
{
    public class Istituzione
    {
        public TASKTYPE _tasktype;
        public List<string> _list;
        public int _time;

        public Istituzione(TASKTYPE task, List<string> list)
        {
            _tasktype = task;
            _list = list;
            _time = 5;
        }

        public string Task()
        {
            return "Task ricevuto";
        }
    }
}
