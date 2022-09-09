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
        static DirectoryInfo TestsFolder => new (MyDocs + "/Patients");

        public static void SavePatienList(List<Patient> patients)
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

        public static List<Patient> GetPatientList()
        {
            if (!PatiensFolder.Exists)
            {
                PatiensFolder.Create();
                return new List<Patient>();
            }

            List<Patient> listOfPatients;

            using (StreamReader file = File.OpenText(PatiensFolder + "\\patients.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                listOfPatients = (List<Patient>)serializer.Deserialize(file, typeof(List<Patient>));

            }

            return listOfPatients;
        }

        public static void SavePatientInfo(PatientInfo patient, TestResult testResult)
        {

            if (!PatiensFolder.Exists)
            {
                PatiensFolder.Create();
            }

            var serializer = new JsonSerializer();
            using (StreamWriter fs = new StreamWriter(PatiensFolder + "\\" + patient.GUID.ToString() + ".json")) // need change later 
            {
                using (var jsonTextWriter = new JsonTextWriter(fs))
                {
                    serializer.Serialize(fs, new { patient, testResult });
                }
            }
        }

        //public static List<Tuple<Info, Tests>> get_patients_info(int guid)
        //{
        //    List<Tuple<Info, Tests>> list;

        //    return list;
        //}
    }
}
