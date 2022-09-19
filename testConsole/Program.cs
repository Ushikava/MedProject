using System;
using Core;
using System.Xml;

namespace testConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Core.Program.CreateExampleTest();
            Core.Program.CreateExamplePatients();
            //JsonWork.LoadTest(Guid.Parse("d4aaeb38-976c-47bd-9f74-345cbd61f0c2"));
        }
    }
}
