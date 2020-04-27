using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Laboratorinis
{
    class Program
    {
        public static Queue<Studentas> vargsiukai = new Queue<Studentas>();
        public static Queue<Studentas> kietiakai = new Queue<Studentas>();

        public static Stopwatch timer = new Stopwatch();
        public static void prideti()
        {

            try
            {
                timer.Start();
                string tempV;
                string tempP;
                double tempE;
                Queue<double> tempB = new Queue<double>();
                Console.WriteLine("Parasykite studento Varda Pavarde Pazymius ir Egzamino bala");
                string tempText = Console.ReadLine();
                char[] delimiters = new char[] { '\r', '\n' };
                string[] parts = tempText.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                // string[] parts = tempText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                tempV = parts[0];
                tempP = parts[1];
                tempE = double.Parse(parts.Last());
                for (int i = 2; i < parts.Length - 1; i++)
                {
                    tempB.Enqueue(double.Parse(parts[i]));
                }
                Studentas tempo = new Studentas(tempV, tempP, tempE, tempB);
                List<Studentas> laikinas = new List<Studentas>();
                if (tempo.Galutinis < 5)
                {
                    vargsiukai.Enqueue(tempo);
                    laikinas = new List<Studentas>();
                    foreach (var item in vargsiukai)
                    {
                        laikinas.Add(item);
                    }
                    laikinas = laikinas.OrderBy(o => o.Vardas).ToList();

                    vargsiukai.Clear();

                    foreach (var item in laikinas)
                    {
                        vargsiukai.Enqueue(item);
                    }
                    laikinas.Clear();
                }
                else
                {
                    kietiakai.Enqueue(tempo);
                    laikinas = new List<Studentas>();
                    foreach (var item in kietiakai)
                    {
                        laikinas.Add(item);
                    }
                    laikinas = laikinas.OrderBy(o => o.Vardas).ToList();

                    kietiakai.Clear();

                    foreach (var item in laikinas)
                    {
                        kietiakai.Enqueue(item);
                    }
                    laikinas.Clear();
                }

                timer.Stop();
                TimeSpan timeTaken = timer.Elapsed;
                string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
                Console.WriteLine(foo);
                timer = new Stopwatch();
            }
            catch (Exception Klaida)
            {
                Console.WriteLine("Ivyko klaida: " + Klaida.Message);
            }


        }
        public static void spausdinti()
        {
            timer.Start();
            Console.WriteLine("{0, -15} {1, -15}{2, -15}{3, -15}", "Pavarde", "Vardas", "Galutinis", "Mediana");
            for (int i=0; i<=60;i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            foreach (var item in kietiakai)
            {
                Console.WriteLine("{0, -15} {1, -15}{2, -15}{3, -15}", item.Pavarde,item.Vardas,item.Galutinis.ToString("0.00"),item.Mediana.ToString("0.00"));
            }
            foreach (var item in vargsiukai)
            {
                Console.WriteLine("{0, -15} {1, -15}{2, -15}{3, -15}", item.Pavarde, item.Vardas, item.Galutinis.ToString("0.00"), item.Mediana.ToString("0.00"));
            }
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            Console.WriteLine(foo);
            timer = new Stopwatch();
        }


        public static void spausdintiGerus()
        {
            timer.Start();
            Console.WriteLine("{0, -15} {1, -15}{2, -15}{3, -15}", "Pavarde", "Vardas", "Galutinis", "Mediana");
            for (int i = 0; i <= 60; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            foreach (var item in kietiakai)
            {
                Console.WriteLine("{0, -15} {1, -15}{2, -15}{3, -15}", item.Pavarde, item.Vardas, item.Galutinis.ToString("0.00"), item.Mediana.ToString("0.00"));
            }
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            Console.WriteLine(foo);
            timer = new Stopwatch();
        }

        public static void spausdintiVargsiukus()
        {
            timer.Start();
            Console.WriteLine("{0, -15} {1, -15}{2, -15}{3, -15}", "Pavarde", "Vardas", "Galutinis", "Mediana");
            for (int i = 0; i <= 60; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            foreach (var item in vargsiukai)
            {
                Console.WriteLine("{0, -15} {1, -15}{2, -15}{3, -15}", item.Pavarde, item.Vardas, item.Galutinis.ToString("0.00"), item.Mediana.ToString("0.00"));
            }
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            Console.WriteLine(foo);
            timer = new Stopwatch();
        }
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Iveskite norima komanda: 1 ivesti, 2 spausdinti, 3 Nuskaityti is failo, 4 Failo generavimas, 5 Kieteku atspausdinimas, 6 vargsiuku atspausdinimas");

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
                    case "4":
                        Generavimas();
                        break;
                    case "5":
                        spausdintiGerus();
                        break;
                    case "6":
                        spausdintiVargsiukus();
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

        private static void Generavimas()
        {
            try
            {
                timer.Start();
                Console.WriteLine("Iveskite norima kieki studentu");
                int studSk = int.Parse(Console.ReadLine());
                string failas = "";
                for (int i = 0; i <= studSk; i++)
                {
                    Random random = new Random();
                    //  return random.Next(min, max);
                    string tempV = "Vardas" + i + " ";
                    string tempP = "Pavarde" + i + " ";
                    double tempE = random.Next(1, 11);
                    Queue<double> tempB = new Queue<double>();
                    double temp = double.Parse(random.Next(1, 11) + "");
                    tempB.Enqueue(temp);
                    temp = double.Parse(random.Next(1, 11) + "");
                    tempB.Enqueue(temp);
                    temp = double.Parse(random.Next(1, 11) + "");
                    tempB.Enqueue(temp);
                    temp = double.Parse(random.Next(1, 11) + "");
                    tempB.Enqueue(temp);
                    temp = double.Parse(random.Next(1, 11) + "");
                    tempB.Enqueue(temp);
                    temp = double.Parse(random.Next(1, 11) + "");
                    tempB.Enqueue(temp);
                    temp = double.Parse(random.Next(1, 11) + "");
                    tempB.Enqueue(temp);
                    temp = double.Parse(random.Next(1, 11) + "");
                    tempB.Enqueue(temp);

                    failas += tempV + tempP;

                    foreach (var item in tempB)
                    {
                        failas += item + " ";
                    }

                    failas += "\n";

                }
                File.WriteAllText(studSk + ".txt", failas);
                timer.Stop();
                TimeSpan timeTaken = timer.Elapsed;
                string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
                Console.WriteLine(foo);
                timer = new Stopwatch();
            }
            catch (Exception Klaida)
            {
                Console.WriteLine("Ivyko klaida: " + Klaida.Message);
            }
        }

        private static void Nuskaityti()
        {
            try
            {
                timer.Start();
                string[] txtfiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
                foreach (var item in txtfiles)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Iveskite norima faila");
                string textinis = Console.ReadLine();
                string[] lines = File.ReadAllLines(textinis);
                Console.WriteLine("Nuskaitome txt faila");
                foreach (string line in lines)
                {
                    try
                    {
                        string tempV;
                        string tempP;
                        double tempE;
                        Queue<double> tempB = new Queue<double>();
                        char[] delimiters = new char[] { '\r', '\n' };
                        string[] parts = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                        // string[] parts = tempText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                        tempV = parts[0];
                        tempP = parts[1];
                        tempE = double.Parse(parts.Last());
                        for (int i = 2; i < parts.Length - 1; i++)
                        {
                            tempB.Enqueue(double.Parse(parts[i]));
                        }
                        Studentas tempo = new Studentas(tempV, tempP, tempE, tempB);
                        List<Studentas> laikinas = new List<Studentas>();
                        if (tempo.Galutinis < 5)
                        {
                            vargsiukai.Enqueue(tempo);
                            laikinas = new List<Studentas>();
                            foreach (var item in vargsiukai)
                            {
                                laikinas.Add(item);
                            }
                            laikinas = laikinas.OrderBy(o => o.Vardas).ToList();

                            vargsiukai.Clear();

                            foreach (var item in laikinas)
                            {
                                vargsiukai.Enqueue(item);
                            }
                            laikinas.Clear();
                        }
                        else
                        {
                            kietiakai.Enqueue(tempo);
                            laikinas = new List<Studentas>();
                            foreach (var item in kietiakai)
                            {
                                laikinas.Add(item);
                            }
                            laikinas = laikinas.OrderBy(o => o.Vardas).ToList();

                            kietiakai.Clear();

                            foreach (var item in laikinas)
                            {
                                kietiakai.Enqueue(item);
                            }
                            laikinas.Clear();
                        }
                    }
                    catch (Exception Klaida)
                    {
                        Console.WriteLine("Ivyko klaida: " + Klaida.Message);
                    }

                }
                Console.WriteLine("Baigeme txt faila");

                timer.Stop();
                TimeSpan timeTaken = timer.Elapsed;
                string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
                Console.WriteLine(foo);
                timer = new Stopwatch();
            }
            catch (Exception Klaida)
            {
                Console.WriteLine("Ivyko klaida: " + Klaida.Message);
            }


        }
    }
}
