using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Test
{
    public class Patient
    {
        public Guid GUID { get; set; }                //id
        public string F_Name { get; set; }            //имя
        public string L_Name { get; set; }            //фамилия
        public string M_Name { get; set; }            //отчество
        public DateTime Research_Date { get; set; }   //дата исследования

        public Patient(string fname, string lname, string mname, DateTime rdate)
        {
            GUID = Guid.NewGuid();
            F_Name = fname;
            L_Name = lname;
            M_Name = mname;
            Research_Date = rdate;
        }

    }

    public class Info
    {
        public Guid GUID { get; set; }              //id
        public string F_Name { get; set; }          //имя
        public string L_Name { get; set; }          //фамилия
        public string M_Name { get; set; }          //отчество
        public DateTime Birthday { get; set; }      //дата рождения
        public string Gender { get; set; }          //может быть только два!
        public string Description { get; set; }     //заметки

        public Info (Guid id, string fname, string lname, string mname, DateTime birth, string gen, string descr)
        {
            GUID = id;
            F_Name = fname;
            L_Name = lname;
            M_Name = mname;
            Birthday = birth;
            Gender = gen;
            Description = descr;
        }
    }

    public class Tests
    {
        public int Sheehan_Test { get; set; }
        public int Representative_Test { get; set; }

        public Tests(int st, int rt)
        {
            Sheehan_Test = st;
            Representative_Test = rt;
        }
    }
}
