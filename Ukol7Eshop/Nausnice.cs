using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ukol7Eshop
{
    internal class Nausnice:Sperk
    {
        public string DruhZapinani;

        public Nausnice(string druhSperku, string sku, string kov, string ryzostKovu, string barvaKovu, string kamen, double hmotnostGramy, double cena, string obrazek, string cestaKObrazku, bool jeSkladem, string nazev, string popis, int pocetKs, string druhZapinani)
        {
            DruhSperku = druhSperku;
            Sku = sku;
            Kov = kov;
            RyzostKovu = ryzostKovu;
            BarvaKovu = barvaKovu;
            Kamen = kamen;
            HmotnostGramy = hmotnostGramy;
            Cena = cena;
            Obrazek = obrazek;
            CestaKObrazku = cestaKObrazku;
            JeSkladem = jeSkladem;
            Nazev = nazev;
            Popis = popis;
            PocetKs = pocetKs;
            DruhZapinani = druhZapinani;
        }
    }
}
