using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorinis.Linked

{
    class Studentas
    {
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public double EgzoBalas { get; set; }
        public LinkedList<double> Pazymiai;
        public double Galutinis { get; set; }
        public double Mediana { get; set; }

        public Studentas(string Vardas, string Pavarde, double EgzoBalas, LinkedList<double> Pazymiai)
        {
            List <double> sortas = new List<double>();
            foreach (var item in Pazymiai)
            {
                sortas.Add(item);
            }
            sortas.Sort();
            Pazymiai.Clear();
            foreach (var item in sortas)
            {
                Pazymiai.AddLast(item);
            }
            sortas.Clear();
            this.Vardas = Vardas;
            this.Pavarde = Pavarde;
            this.EgzoBalas = EgzoBalas;
            this.Pazymiai = Pazymiai;
            double temp = 0;
            for (int i = 0; i < Pazymiai.ToList().Count; i++)
            {
                temp += Pazymiai.ToList()[i];
            }
            temp /= Pazymiai.Count;
            this.Galutinis = 0.3 * temp + 0.7 * EgzoBalas;
            this.Mediana = 0.3 * Pazymiai.ToList()[Pazymiai.Count / 2] + 0.7 * EgzoBalas;
        }
    }
}
