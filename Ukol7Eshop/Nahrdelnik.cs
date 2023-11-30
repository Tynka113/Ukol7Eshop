using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ukol7Eshop
{
    public class Nahrdelnik : Sperk
    {
        public int DelkaNahrdelniku;

        public Nahrdelnik(string sku, string kov, string ryzostKovu, string barvaKovu, string kamen, double hmotnostGramy, double cena, string obrazek, string cestaKObrazku, bool jeSkladem, string nazev, string popis, int pocetKs, int delkaNahrdelniku) : base("Nahrdelnik", sku, kov, ryzostKovu, barvaKovu, kamen, hmotnostGramy, cena, obrazek, cestaKObrazku, jeSkladem, nazev, popis, pocetKs)
        {
            DelkaNahrdelniku = delkaNahrdelniku;
        }
    }
}
