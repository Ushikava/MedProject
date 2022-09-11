using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Collections;

namespace Test
{
    public class JsonWork
    {
        //const string MyDocs = "/TestProgramm/Patients";
        static string MyDocs => Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\TestProgramm";
        static FileInfo PatiensFile => new (MyDocs + @"\Patients\patients.json");
        static DirectoryInfo PatiensFolder => new (MyDocs + @"\Patients");
        static DirectoryInfo TestsFolder => new (MyDocs + @"\Tests");
        static FileInfo TestsFile => new (MyDocs + @"\Tests\Tests.json");

        #region Patients
        public static void SavePatientsInfoList(List<PatientInfo> patients)
        {
            if (!PatiensFolder.Exists)
            {
                PatiensFolder.Create();
            }

            var serializer = new JsonSerializer();
            using (var fs = new StreamWriter(PatiensFile.FullName))
            {
                using (var jsonTextWriter = new JsonTextWriter(fs))
                {
                    serializer.Serialize(fs, patients);
                }
            }
        }

        public static List<PatientInfo> LoadPatientsInfoList()
        {
            if (!PatiensFile.Exists)
            {
                PatiensFile.Create();
                return new List<PatientInfo>();
            }

            List<PatientInfo> listOfPatients;

            using (StreamReader file = File.OpenText(PatiensFile.FullName))
            {
                JsonSerializer serializer = new JsonSerializer();

                listOfPatients = (List<PatientInfo>)serializer.Deserialize(file, typeof(List<PatientInfo>));

            }

            return listOfPatients;
        }



        public static void SavePatient(Patient patient)
        {

            if (!PatiensFolder.Exists)
            {
                PatiensFolder.Create();
            }

            var serializer = new JsonSerializer();
            using (StreamWriter fs = new StreamWriter(PatiensFolder + "\\" + patient.GUID.ToString() + ".json"))
            {
                using (var jsonTextWriter = new JsonTextWriter(fs))
                {
                    serializer.Serialize(fs, patient);
                }
            }
        }

        public static Patient LoadPatient(Guid guid)
        {
            var patient = Patient.EMPTY;

            if (!PatiensFolder.Exists)
            {
                PatiensFolder.Create();
                return Patient.EMPTY;
            }


            using (StreamReader fs = new StreamReader($@"{PatiensFolder.FullName}\{guid}.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                patient = (Patient)serializer.Deserialize(fs, typeof(Patient));
            }

            return patient;
        }

        public static void DeletePatient(Guid guid)
        {
            FileInfo fileInfo = GetPatientFileInfo(guid);
            if (fileInfo.Exists)
                fileInfo.Delete();
        }

        public static FileInfo GetPatientFileInfo(Guid guid)
        {
            FileInfo fileInfo = new FileInfo($@"{PatiensFolder.FullName}\{guid}.json");
            return fileInfo;
        }
        #endregion

        #region Tests
        public static void SaveTestInfoList(List<TestInfo> testInfos)
        {
            if (TestsFolder.Exists == false)
            {
                TestsFolder.Create();
            }

            var serializer = new JsonSerializer();
            using (StreamWriter fs = new StreamWriter(TestsFile.FullName))
            {
                using (var jsonTextWriter = new JsonTextWriter(fs))
                {
                    serializer.Serialize(fs, testInfos);
                }
            }
        }
        public static List<TestInfo> LoadTestInofList()
        {
            var testsInfoList = new List<TestInfo>();

            if (TestsFile.Exists == false)
            {
                TestsFile.Create();
                return testsInfoList;
            }

            using (StreamReader file = File.OpenText(TestsFile.FullName))
            {
                JsonSerializer serializer = new JsonSerializer();
                testsInfoList = (List<TestInfo>)serializer.Deserialize(file, typeof(List<TestInfo>));
            }

            return testsInfoList;
        }



        public static void SaveTest(Test test)
        {

            if (!TestsFolder.Exists)
            {
                TestsFolder.Create();
            }

            using (StreamWriter fs = new StreamWriter(TestsFolder + "\\" + test.GUID.ToString() + ".json"))
            {
                var serializer = new JsonSerializer();
                using (var jsonTextWriter = new JsonTextWriter(fs))
                {
                    serializer.Serialize(fs, test);
                }
            }
        }
        public static void LoadTest(Guid guid)
        {
            using (StreamReader fs = new StreamReader($"{TestsFolder}\\{guid.ToString()}.json"))
            {
                var serializer = new JsonSerializer();
                var t = (Test)serializer.Deserialize(fs, typeof(Test));
            }
        }

        #endregion
    }







    #region QuestionCOnverter
    public class SubTypeClassConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Question);
        }

        public override bool CanWrite { get { return false; } }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = Newtonsoft.Json.Linq.JToken.Load(reader);
            var typeToken = token["Type"];
            if (typeToken == null)
                throw new InvalidOperationException("invalid object");
            var actualType = Question.GetType(typeToken.ToObject<SubType>(serializer));
            if (existingValue == null || existingValue.GetType() != actualType)
            {
                var contract = serializer.ContractResolver.ResolveContract(actualType);
                existingValue = contract.DefaultCreator();
            }
            using (var subReader = token.CreateReader())
            {
                // Using "populate" avoids infinite recursion.
                serializer.Populate(subReader, existingValue);
            }
            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}
