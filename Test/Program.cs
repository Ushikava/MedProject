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
            PatientInfo patient = new PatientInfo();
            patient.F_Name = "1";

            TestResult testResult = new("test1", "ok");
            testResult.GUID = Guid.NewGuid();
            testResult.AddTagResult("def", 100);

            JsonWork.SavePatientInfo(patient, testResult);

            //List<Patient> ptlist = new List<Patient>();
            //var pt = new Patient("имя", "фамилия", "отчество", DateTime.Now);

            //ptlist.Add(new Patient("1", "0", "o", DateTime.Now));
            //ptlist.Add(new Patient("2", "0", "o", DateTime.Now));
            //ptlist.Add(new Patient("3", "0", "o", DateTime.Now));

            //JsonWork.SavePatienList(ptlist);
            //var list = JsonWork.GetPatientList();
            //foreach (var one in list)
            //{
            //    Console.WriteLine(one.F_Name);
            //}
        }
    }
}
