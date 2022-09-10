using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Test
{
    public class JsonWork
    {
        //const string MyDocs = "/TestProgramm/Patients";
        static string MyDocs => Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\TestProgramm";
        static DirectoryInfo PatiensFolder => new (MyDocs + @"\Patients");
        static DirectoryInfo TestsFolder => new (MyDocs + @"\Tests");

        #region Patients
        public static void SaveListOfPatientInfo(List<PatientInfo> patients)
        {
            if (!PatiensFolder.Exists)
            {
                PatiensFolder.Create();
            }

            var serializer = new JsonSerializer();
            using (StreamWriter fs = new StreamWriter(PatiensFolder + "\\patients.json"))
            {
                using (var jsonTextWriter = new JsonTextWriter(fs))
                {
                    serializer.Serialize(fs, patients);
                }
            }
        }

        public static List<PatientInfo> LoadListOfPatientInfo()
        {
            if (!PatiensFolder.Exists)
            {
                PatiensFolder.Create();
                return new List<PatientInfo>();
            }

            List<PatientInfo> listOfPatients;

            using (StreamReader file = File.OpenText(PatiensFolder + "\\patients.json"))
            {
                JsonSerializer serializer = new JsonSerializer();

                //listOfPatients
                listOfPatients = (List<PatientInfo>)serializer.Deserialize(file, typeof(List<PatientInfo>));

            }

            return listOfPatients;
        }

        public static void SavePatient(Patient patient, IEnumerable<TestResult> testResult)
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
                    serializer.Serialize(fs, new { patient, testResult});
                }
            }
        }

        public static (Patient patient, List<TestResult> testResult) GetPatientInfo(Guid guid)
        {
            var tests = new List<TestResult>();
            var patient = new { patient = Patient.EMPTY, testResult = tests};

            if (!PatiensFolder.Exists)
            {
                PatiensFolder.Create();
                return (patient.patient, patient.testResult);
            }


            using (StreamReader fs = new StreamReader(PatiensFolder + "\\" + guid.ToString() + ".json"))
            {
                patient = JsonConvert.DeserializeAnonymousType(fs.ReadToEnd(), patient);
            }

            return (patient.patient, patient.testResult);
        }

        #endregion

        #region 

        public static void SaveTest(Test test)
        {

            if (!TestsFolder.Exists)
            {
                TestsFolder.Create();
            }

            var serializer = new JsonSerializer();
            using (StreamWriter fs = new StreamWriter(TestsFolder + "\\" + test.GUID.ToString() + ".json"))
            {
                using (var jsonTextWriter = new JsonTextWriter(fs))
                {
                    serializer.Serialize(fs, test);
                }
            }
        }

        #endregion
    }
}
