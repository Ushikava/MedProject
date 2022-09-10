using System;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace Test
{
    public class Program
    {
        public static void CreateExampleTest()
        {
            Test t = new Test(
                "test1", 
                "just test1", 
                new() { Test.DEFAULT_TAG }, 
                new() {
                    new QuestionRateAnswer() { 
                        Text="quest1",
                        Answers = new() { "ans 1", "ans 2", "ans 3", "ans 4"},
                        AnswerTags = new() { Test.DEFAULT_TAG },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = true
                    },
                    new Question()
                    {
                        Text = "quest2",
                        Answers = new() { "ans 1", "ans 2", "ans 3", "ans 4" },
                        AnswerTags = new() { Test.DEFAULT_TAG }
                    },
                    new QuestionTest()
                    {
                        Text = "quest3",
                        Answers = new() { "ans 1", "ans 2", "ans 3", "ans 4" },
                        AnswerTags = new() { Test.DEFAULT_TAG },
                    }
                },
                new() {
                    { 
                        Test.DEFAULT_TAG , new (){
                            { "no",  3 },
                            { "mb",  2 },
                            { "yes", 1 }
                        }
                    }
                }
                );
            JsonWork.SaveTest(t);
        }
        public static void CreateExamplePatients()
        {

            var rnd = new Random();
            List<PatientInfo> ptlist = new List<PatientInfo>();
            List<Patient> ptInfos = new List<Patient>();

            ptInfos.Add(new Patient("Al", "Van", "Hell", new DateTime(1999, 2, 1), "муж"));
            ptInfos.Add(new Patient("Den", "0_o", "Morti", new DateTime(1995, 5, 11), "муж"));
            ptInfos.Add(new Patient("Ig", "Rock", "uwu", new DateTime(2005, 3, 23), "муж"));
            ptlist.Add(ptInfos[0].GetPatientCut());
            ptlist.Add(ptInfos[1].GetPatientCut());
            ptlist.Add(ptInfos[2].GetPatientCut());


            List<TestResult> tr = new();
            TestResult testResult = new("test1", "ok");
            testResult.GUID = Guid.NewGuid();
            testResult.results = new List<TagResult>{ new( "def", 100) };
            testResult.completeTime = DateTime.Now - new TimeSpan(1, 10, 1, 0);
            tr.Add(testResult);
            testResult = new("test2", "mb");
            testResult.GUID = Guid.NewGuid();
            testResult.results = new List<TagResult> { new("def", 50 ), new("K", 50 )};
            testResult.completeTime = DateTime.Now - new TimeSpan(7, 10, 1, 0);
            tr.Add(testResult);
            JsonWork.SavePatient(ptInfos[0], tr);
            tr.Clear();

            testResult = new("test1", "no");
            testResult.GUID = Guid.NewGuid();
            testResult.results = new List<TagResult> { new("def", 130 ) };
            testResult.completeTime = DateTime.Now - new TimeSpan(10, 1, 0);
            tr.Add(testResult);
            JsonWork.SavePatient(ptInfos[1], tr);
            tr.Clear();

            testResult = new("test1", "mb");
            testResult.GUID = Guid.NewGuid();
            testResult.results = new List<TagResult> { new("def", 50) };
            testResult.completeTime = DateTime.Now - new TimeSpan(25 ,10, 1, 0);
            tr.Add(testResult);
            JsonWork.SavePatient(ptInfos[2], tr);
            tr.Clear();

            JsonWork.SaveListOfPatientInfo(ptlist);
        }
    }
}
