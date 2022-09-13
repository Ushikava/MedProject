using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Core
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
        public static Test EMPTY => new Test();

        private Test()
        {
            GUID = Guid.Empty;
        }
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

    public enum SubType
    {
        Question,
        QuestionRateAnswer,
        QuestionTest,
    }

    [JsonConverter(typeof(SubTypeClassConverter))]
    public class Question
    {
        static readonly Dictionary<Type, SubType> typeToSubType;
        static readonly Dictionary<SubType, Type> subTypeToType;

        static Question()
        {
            typeToSubType = new Dictionary<Type, SubType>()
            {
                { typeof(Question), SubType.Question },
                { typeof(QuestionRateAnswer), SubType.QuestionRateAnswer },
                { typeof(QuestionTest), SubType.QuestionTest },
            };
            subTypeToType = typeToSubType.ToDictionary(pair => pair.Value, pair => pair.Key);
        }

        public static Type GetType(SubType subType)
        {
            return subTypeToType[subType];
        }

        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))] // Serialize enums by name rather than numerical value
        public SubType Type => typeToSubType[GetType()];


        public string Text { get; set; }
        public List<string> Variants { get; set; }
        public List<string> VariantsTag { get; set; } = new List<string>();



        [JsonIgnore]
        public List<int> Answers { get; set; }

        public virtual bool AnswerIsCorrect() {
            return Answers.Any((v) => v > 0);
        }
        public void ClearAnswers()
        {
            Answers = new List<int>();
            foreach (var _ in Variants)
                Answers.Add(0);
        }
        public Dictionary<string, int> GetAnswers()
        {
            var res = new Dictionary<string, int>();

            if (VariantsTag.Count > 1)
                for (int i = 0; i < VariantsTag.Count; i++)
                {
                    if (res.Keys.Contains(VariantsTag[i]))
                        res[VariantsTag[i]] += Answers[i];
                    else
                        res.Add(VariantsTag[i], Answers[i]);
                }
            else
            {
                res.Add(Test.DEFAULT_TAG, 0);
                for (int i = 0; i < Variants.Count; i++)
                    res[Test.DEFAULT_TAG] += Answers[i];
            }

            return res;
        }
    }
    public class QuestionRateAnswer : Question
    {
        public int MaxRate { get; set; }
        public int MinRate { get; set; }
        public bool UnicValues { get; set; }
        public override bool AnswerIsCorrect()
        {
            if(UnicValues)
                return Answers.Distinct().Count() == Answers.Count;
            return Answers.Any((v) => v > 0);
        }

    }
    public class QuestionTest : Question
    {
        public string Foo { get; set; } = "Foo";
        public override bool AnswerIsCorrect()
        {
            return false;
        }

    }
}
