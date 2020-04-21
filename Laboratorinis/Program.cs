using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Laboratorinis
{
    class Program
    {
        public static List<Studentas> studentai = new List<Studentas>();
        public static void prideti()
        {
            string tempV;
            string tempP;
            double tempE;
            List<double> tempB = new List<double>();
            Console.WriteLine("Parasykite studento Varda Pavarde Pazymius ir Egzamino bala");
            string tempText = Console.ReadLine();
            char[] delimiters = new char[] { '\r', '\n' };
            string[] parts = tempText.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
           // string[] parts = tempText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            tempV = parts[0];
            tempP = parts[1];
            tempE =double.Parse (parts.Last());
            for (int i =2; i < parts.Length - 1; i++)
            {
                tempB.Add(double.Parse (parts[i]));
            }
            studentai.Add(new Studentas(tempV, tempP, tempE, tempB));
            studentai = studentai.OrderBy(o => o.Vardas).ToList();

        }
        public static void spausdinti()
        {
            Console.WriteLine("{0, -15} {1, -15}{2, -15}{3, -15}", "Pavarde", "Vardas", "Galutinis", "Mediana");
            for (int i=0; i<=60;i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            foreach (var item in studentai)
            {
                Console.WriteLine("{0, -15} {1, -15}{2, -15}{3, -15}", item.Pavarde,item.Vardas,item.Galutinis.ToString("0.00"),item.Mediana.ToString("0.00"));
            }
        }
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Iveskite norima komanda: 1 ivesti, 2 spausdinti");

            bool Isejimas = true;
            while(Isejimas)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        prideti();   
                        break;
                    case "2":
                        spausdinti();
                        break;
                    case "3":
                        Nuskaityti();
                        break;
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

        private static void Nuskaityti()
        {
            string[] lines = File.ReadAllLines("pazymiai.txt");
            Console.WriteLine("Nuskaitome txt faila");
            foreach (string line in lines)
            {
                string tempV;
                string tempP;
                double tempE;
                List<double> tempB = new List<double>();
                char[] delimiters = new char[] { '\r', '\n' };
                string[] parts = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                // string[] parts = tempText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                tempV = parts[0];
                tempP = parts[1];
                tempE = double.Parse(parts.Last());
                for (int i = 2; i < parts.Length - 1; i++)
                {
                    tempB.Add(double.Parse(parts[i]));
                }
                studentai.Add(new Studentas(tempV, tempP, tempE, tempB));
            }
            Console.WriteLine("Baigeme txt faila");

            studentai = studentai.OrderBy(o => o.Vardas).ToList();

        }
    }
}
