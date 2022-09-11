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
                new()
                {
                    new QuestionRateAnswer()
                    {
                        Text = "quest1",
                        Answers = new() { "ans 1", "ans 2", "ans 3", "ans 4" },
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
                new()
                {
                    {
                        Test.DEFAULT_TAG,
                        new()
                        {
                            { "no", 3 },
                            { "mb", 2 },
                            { "yes", 1 }
                        }
                    }
                }
                );
            Test t2 = new Test(
                "test2",
                "another test, test2",
                new() { Test.DEFAULT_TAG, "K", "V", "A", "D" },
                new()
                {
                    new QuestionRateAnswer()
                    {
                        Text = "quest1",
                        Answers = new() { "ans 1", "ans 2", "ans 3", "ans 4" },
                        AnswerTags = new() { "K", "V", "A", "D" },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = false
                    },
                    new QuestionRateAnswer()
                    {
                        Text = "quest2",
                        Answers = new() { "ans 1", "ans 4", "ans 3", "ans 2" },
                        AnswerTags = new() { "K", "D", "A", "V" },
                        MaxRate = 4,
                        MinRate = 0,
                        UnicValues = true
                    },
                },
                new()
                {
                    {
                        Test.DEFAULT_TAG,
                        new()
                        {
                            { "no", 3 },
                            { "mb", 2 },
                            { "yes", 1 }
                        }
                    },
                    { "K", new() { { "K isn`t ok", 3 }, { "K is ok", 1 }, { "K is perfect", 0 } } },
                    { "V", new() { { "V isn`t ok", 3 }, { "V is ok", 1 }, { "V is perfect", 0 } } },
                    { "A", new() { { "A isn`t ok", 3 }, { "A is ok", 1 }, { "A is perfect", 0 } } },
                    { "D", new() { { "D isn`t ok", 3 }, { "D is ok", 1 }, { "D is perfect", 0 } } },
                }
                );
            JsonWork.SaveTest(t);
            JsonWork.SaveTest(t2);
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


            TestResult testResult = new("test1", "ok");
            testResult.TestGUID = Guid.NewGuid();
            testResult.results = new List<TagResult>{ new( "def", 100) };
            testResult.completeTime = DateTime.Now - new TimeSpan(1, 10, 1, 0);
            ptInfos[0].TestResults.Add(testResult);
            testResult = new("test2", "mb");
            testResult.TestGUID = Guid.NewGuid();
            testResult.results = new List<TagResult> { new("def", 50 ), new("K", 50 )};
            testResult.completeTime = DateTime.Now - new TimeSpan(7, 10, 1, 0);
            ptInfos[0].TestResults.Add(testResult);
            JsonWork.SavePatient(ptInfos[0]);

            testResult = new("test1", "no");
            testResult.TestGUID = Guid.NewGuid();
            testResult.results = new List<TagResult> { new("def", 130 ) };
            testResult.completeTime = DateTime.Now - new TimeSpan(10, 1, 0);
            ptInfos[1].TestResults.Add(testResult);
            JsonWork.SavePatient(ptInfos[1]);

            testResult = new("test1", "mb");
            testResult.TestGUID = Guid.NewGuid();
            testResult.results = new List<TagResult> { new("def", 50) };
            testResult.completeTime = DateTime.Now - new TimeSpan(25 ,10, 1, 0);
            ptInfos[2].TestResults.Add(testResult);
            JsonWork.SavePatient(ptInfos[2]);

            JsonWork.SaveListOfPatientInfo(ptlist);
        }
        public static Patient CreateExamplePatient()
        {
            Patient pt = new Patient("Al", "Van", "Hell", new DateTime(1999, 2, 1), "муж");

            TestResult testResult = new("test1", "ok");
            testResult.TestGUID = Guid.NewGuid();
            testResult.results = new List<TagResult> { new("def", 4) };
            testResult.completeTime = DateTime.Now - new TimeSpan(7, 10, 1, 0);
            pt.TestResults.Add(testResult);
            testResult = new("test2", "mb");
            testResult.TestGUID = Guid.NewGuid();
            testResult.results = new List<TagResult> { new("def", 2), new("K",3), new("A", 1), new("V", 2), new("D", 1) };
            testResult.completeTime = DateTime.Now - new TimeSpan(7, 10, 1, 0);
            pt.TestResults.Add(testResult);
            testResult = new("test2", "mb");
            testResult.TestGUID = Guid.NewGuid();
            testResult.results = new List<TagResult> { new("def", 2), new("K",3), new("A", 1), new("V", 2), new("D", 1) };
            testResult.completeTime = DateTime.Now - new TimeSpan(7, 10, 1, 0);
            pt.TestResults.Add(testResult);
            testResult = new("test2", "mb");
            testResult.TestGUID = Guid.NewGuid();
            testResult.results = new List<TagResult> { new("def", 2), new("K",3), new("A", 1), new("V", 2), new("D", 1) };
            testResult.completeTime = DateTime.Now - new TimeSpan(7, 10, 1, 0);
            pt.TestResults.Add(testResult);
            return pt;
        }
    }
}
