using System;
using System.Collections.Generic;
using System.Threading;
using LawyerOffice.Contracts;
using LawyerOffice.Service;

namespace LawyerOffice.Implementation
{
    public class TaskDelivery
    {
        List<Istituzione> listi;

        public TaskDelivery()
        {
            listi = SigData.Istituziones();
        }
        public Istituzione GetTask(TASKTYPE taskt)
        {
            foreach (var item in listi)
            {
                    if (item._tasktype == taskt)
                        return item;
            }
            return null;
        }
        public void ritornaT (DateTime time, TASKTYPE taskt, DelegateperOra del)
        {
            DateTime oraconsegna = time.AddSeconds(GetTask(taskt)._time);

            del($"L'ordine Preso in carico: {time} Ora prevista consegna: {oraconsegna}");
        }
        public string DeliveryTask(TASKTYPE taskt)
        {
            Console.WriteLine("Il task sta arrivando..");
            Thread.Sleep(5000);

            var taskr = GetTask(taskt).Task();
            return taskr;
        }
    }
}
