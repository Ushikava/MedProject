using System;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            Guid newId = Guid.NewGuid();
            DateTime data = DateTime.Now;
            List<Tuple<Info, Tests>> list = new List<Tuple<Info, Tests>>();
            var ptinf = new Info(newId, "имя", "фамилия", "отчество", data, "м", "больной");
            var testInf = new Tests(34, 35);
            var summ = Tuple.Create(ptinf, testInf);
            list.Add(summ);
            Console.WriteLine(summ.Item1);
            JsonWork.add_patient_info(list);

            //List<Patient> ptlist = new List<Patient>();
            //var pt = new Patient("имя", "фамилия", "отчество", "дата");

            //ptlist.Add(pt);
            //ptlist.Add(pt);
            //ptlist.Add(pt);

            //JsonWork.add_patient(ptlist);
            //var list = JsonWork.get_patients();
            //foreach (var one in list)
            //{
            //    Console.WriteLine(one.M_Name);
            //}
        }
    }
}
