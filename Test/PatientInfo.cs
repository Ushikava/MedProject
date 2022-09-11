using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Test
{
    public class PatientInfo
    {
        public Guid GUID { get; set; } = Guid.Empty;  //id
        public string F_Name { get; set; }            //имя
        public string L_Name { get; set; }            //фамилия
        public string M_Name { get; set; }            //отчество
        public DateTime Research_Date { get; set; }   //дата исследования

        public static PatientInfo EMPTY => new PatientInfo();

        private PatientInfo() { }
        public PatientInfo(string fname, string lname, string mname, DateTime rdate)
        {
            GUID = Guid.NewGuid();
            F_Name = fname;
            L_Name = lname;
            M_Name = mname;
            Research_Date = rdate;
        }

    }

    public class Patient
    {
        public Guid GUID { get; set; } = Guid.Empty;//id
        public string F_Name { get; set; }          //имя
        public string L_Name { get; set; }          //фамилия
        public string M_Name { get; set; }          //отчество
        public DateTime Birthday { get; set; }      //дата рождения
        public string Gender { get; set; }          //может быть только два!
        public string Description { get; set; }     //заметки
        public List<TestResult> TestResults { get; set; } = new();
        public static Patient EMPTY => new Patient();

        private Patient ()
        {
            GUID = Guid.Empty;
        }
        public Patient (string fname, string lname, string mname, DateTime birth, string gen, string descr="")
        {
            GUID = Guid.NewGuid();
            F_Name = fname;
            L_Name = lname;
            M_Name = mname;
            Birthday = birth;
            Gender = gen;
            Description = descr;
        }

        public PatientInfo GetPatientCut()
        {
            return new PatientInfo(F_Name, L_Name, M_Name, DateTime.Now)
            {
                GUID = GUID,
                Research_Date = TestResults.OrderBy(r => r.completeTime).Last().completeTime
            };
        }
    }

    public class TestResult
    {
        public Guid TestGUID { get; set; }
        public string TestName { get; set; }
        public string diagnosis { get; set; }
        public List<TagResult> results { get; set; } = new();
        public DateTime completeTime { get; set; }

        public TestResult(string st, string rt)
        {
            TestName = st;
            diagnosis = rt;
        }
    }
}
