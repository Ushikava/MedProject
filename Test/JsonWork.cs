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
        public static void add_patient(List<Patient> patients)
        {
            string mydocu = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            mydocu += "/TestProgramm/Patients";
            var directory = new DirectoryInfo(mydocu);
            
            if (!directory.Exists)
            {
                Directory.CreateDirectory(mydocu);
            }

            var serializer = new JsonSerializer();
            using (StreamWriter fs = new StreamWriter(mydocu + "\\patients.json"))
            {
                using (var jsonTextWriter = new JsonTextWriter(fs))
                {
                    serializer.Serialize(fs, patients);
                }
            }
        }

        public static List<Patient> get_patients()
        {
            List<Patient> listOfPatients;
            using (StreamReader file = File.OpenText(@"patients.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                listOfPatients = (List<Patient>)serializer.Deserialize(file, typeof(List<Patient>));
            }
            return listOfPatients;
        }

        public static void add_patient_info(List<Tuple<Info, Tests>> patient)
        {
            string mydocu = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            mydocu += "/TestProgramm/Patients";
            var directory = new DirectoryInfo(mydocu);

            if (!directory.Exists)
            {
                Directory.CreateDirectory(mydocu);
            }

            var patientInfo = patient[0].Item1;
            var serializer = new JsonSerializer();
            using (StreamWriter fs = new StreamWriter(mydocu + '\\' + patientInfo.GUID + ".json")) // need change later 
            {
                using (var jsonTextWriter = new JsonTextWriter(fs))
                {
                    serializer.Serialize(fs, patient);
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
