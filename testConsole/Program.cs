using System;
using Test;

namespace testConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test.Program.CreateExampleTest();
            JsonWork.LoadTest(Guid.Parse("d4aaeb38-976c-47bd-9f74-345cbd61f0c2"));
            Console.WriteLine("Hello World!");
        }
    }
}
