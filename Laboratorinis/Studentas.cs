using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorinis
{
    class Studentas
    {
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public double EgzoBalas { get; set; }
        public List<double> Pazymiai;
        public double Galutinis { get; set; }
        public double Mediana { get; set; }

        public Studentas(string Vardas, string Pavarde, double EgzoBalas, List<double> Pazymiai)
        {
            this.Vardas = Vardas;
            this.Pavarde = Pavarde;
            this.EgzoBalas = EgzoBalas;
            this.Pazymiai = Pazymiai;
            this.Pazymiai.Sort();
            double temp = 0;
            for (int i = 0; i < Pazymiai.Count; i++)
            {
                temp += Pazymiai[i];
            }
            temp /= Pazymiai.Count;
            this.Galutinis = 0.3 * temp + 0.7 * EgzoBalas;
            this.Galutinis = 0.3 * Pazymiai[Pazymiai.Count / 2] + 0.7 * EgzoBalas;
        }
    }
}
