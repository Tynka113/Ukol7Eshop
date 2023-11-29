using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ukol7Eshop
{
    public class Sperk
    {
        public string DruhSperku;
        public string Sku;
        public string Kov;
        public string RyzostKovu;
        public string BarvaKovu;
        public string Kamen;
        public double HmotnostGramy;
        public double Cena;
        public string Obrazek;
        public string CestaKObrazku;
        public bool JeSkladem;
        public string Nazev;
        public string Popis;
        public int PocetKs;

        public string Naskladni(int pocet)
        {
            PocetKs = PocetKs + pocet;
            return "Naskladněno: " + pocet + " ks - nyní je na skladě: " + PocetKs + " ks";
        }
        public string Prodej(int pocet)
        {
            if (PocetKs > pocet || PocetKs == pocet)
            {
                PocetKs = PocetKs - pocet;
                return "Vyskladněno: " + pocet + " ks, zbývá: " + PocetKs;
            }
            else
            {
                return "Nelze prodat, na skladě je pouze " + PocetKs + " ks";
            }
        }
    }
}
