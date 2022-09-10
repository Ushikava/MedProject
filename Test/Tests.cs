using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TestInfo
    {
        public Guid GUID { get; set; }
        public string Name { get; set; }
        public TestInfo(Guid guid, string name)
        {
            GUID = guid;
            Name = name;
        }

    }
    public class Test
    {
        public const string DEFAULT_TAG = "def";
        public Guid GUID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> AnswerTags { get; set; } = new List<string>() { DEFAULT_TAG };
        public List<Question> QuestionList { get; set; }
        public Dictionary<string, Dictionary<string, int>> Diagnoses { get; set; }
        private Test()
        { }
        public Test(
            string name, string description, 
            List<string> answerTags, 
            List<Question> questionList, 
            Dictionary<string, Dictionary<string, int>> diagnoses)
        {
            GUID = Guid.NewGuid();
            Name = name;
            Description = description;
            AnswerTags = answerTags;
            QuestionList = questionList;
            Diagnoses = diagnoses;

        }
        public TestInfo GetTestInfo()
        {
            return new TestInfo(GUID, Name);
        }
    }
    public struct TagResult
    {
        public string Tag { get; set; }
        public int Result { get; set; }
        public TagResult(string tag, int result)
        {
            Tag = tag;
            Result = result;
        }
    }
    public class Question
    {
        public string Text { get; set; }
        public List<string> Answers { get; set; }
        public List<string> AnswerTags { get; set; } = new List<string>() { Test.DEFAULT_TAG };
    }
    public class QuestionTest : Question
    {
        public string Foo { get; set; } = "Foo";
    }
    public class QuestionRateAnswer : Question
    {
        public int MaxRate { get; set; }
        public int MinRate { get; set; }
        public bool UnicValues { get; set; }
    }
}
