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
            var list = JsonWork.LoadPatientList();
            foreach (var one in list)
            {
                Console.WriteLine(one.F_Name);
            }
        }

        public static void CreateTestPatients()
        {

            var rnd = new Random();
            List<Patient> ptlist = new List<Patient>();
            List<PatientInfo> ptInfos = new List<PatientInfo>();

            ptInfos.Add(new PatientInfo("Al", "Van", "Hell", new DateTime(1999, 2, 1), "муж"));
            ptInfos.Add(new PatientInfo("Den", "0_o", "Morti", new DateTime(1995, 5, 11), "муж"));
            ptInfos.Add(new PatientInfo("Ig", "Rock", "uwu", new DateTime(2005, 3, 23), "муж"));
            ptlist.Add(ptInfos[0].GetPatientCut());
            ptlist.Add(ptInfos[1].GetPatientCut());
            ptlist.Add(ptInfos[2].GetPatientCut());


            List<TestResult> tr = new();
            TestResult testResult = new("test1", "ok");
            testResult.GUID = Guid.NewGuid();
            testResult.results = new Dictionary<string, int>{ { "def", 100} };
            tr.Add(testResult);
            testResult = new("test2", "mb");
            testResult.GUID = Guid.NewGuid();
            testResult.results = new Dictionary<string, int>{ { "def", 50 }, { "K", 50 } };
            tr.Add(testResult);
            JsonWork.SavePatientInfo(ptInfos[0], tr);
            tr.Clear();

            testResult = new("test1", "no");
            testResult.GUID = Guid.NewGuid();
            testResult.results = new Dictionary<string, int>{ { "def", 130 } };
            tr.Add(testResult);
            JsonWork.SavePatientInfo(ptInfos[1], tr);
            tr.Clear();

            testResult = new("test1", "mb");
            testResult.GUID = Guid.NewGuid();
            testResult.results = new Dictionary<string, int>{ { "def", 50 } };
            tr.Add(testResult);
            JsonWork.SavePatientInfo(ptInfos[2], tr);
            tr.Clear();

            JsonWork.SavePatienList(ptlist);
        }
    }
}
