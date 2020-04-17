using System;

namespace Laboratorinis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Iveskite norima komanda:");
            Console.WriteLine("Iveskite norima komanda:");

            bool Isejimas = true;
            while(Isejimas)
            {
                switch (Console.ReadLine())
                {
                    default:
                        Console.WriteLine("Nerasta komanda");
                        Main(args);
                        break;
                    case "exit":
                        Isejimas = false;
                        break;
                }
            }
                
        }
    }
}
