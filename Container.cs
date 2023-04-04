using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Osztalyaim
{
    public class Tartaly
    {
        string nev;
        int a, b, c;
        double aktLiter;

        public Tartaly(string nev, int a, int b, int c)
        {
            this.nev = nev;
            this.a = a;
            this.b = b;
            this.c = c;
            this.aktLiter = 0;
        }

        public Tartaly(String nev)
        {
            this.nev = nev;
            this.a = 10;
            this.b = 10;
            this.c = 10;
            this.aktLiter = 0;
        }

        public double Terfogat
        {
            get { return this.a * this.b * this.c / 1000d; }
        }

        public void DuplazMeretet()
        {
            this.a *= 2;
        }

        public void TeljesLeengedes()
        {
            this.aktLiter = 0;
        }

        public double Toltottseg
        {
            get => (this.aktLiter / Terfogat) * 100;
        }
        public string Nev { get => nev; }
        public int A { get => a; }
        public int B { get => b; }
        public int C { get => c; }
        public double AktLiter { get => aktLiter; }

        public void Tolt(double mennyit)
        {
            if (Terfogat < this.aktLiter + mennyit)
            {
                MessageBox.Show("Túlfolyás");
            }
            this.aktLiter += mennyit;
        }


        public string Info()
        {
            return $"{this.nev}: {this.Terfogat * 1000:n1} cm3 = ({this.Terfogat:n2} liter)," +
                $" töltöttsége: {this.Toltottseg:n2}%, ({this.aktLiter:n2} liter)," +
                $" méretei: {this.a}x{this.b}x{this.c} cm";

        }
    }
}
