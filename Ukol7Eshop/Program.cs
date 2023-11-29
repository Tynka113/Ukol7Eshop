using System.Text;
using Ukol7Eshop;
using static System.Net.Mime.MediaTypeNames;

/*
Pokus se vytvořit takový simulátor e-shopu.
Udelej zakladní třídu např.: Odev, která bude mít 
společné vlastnosti pro poděděné třídy, 
tedy např.: cena, velikost, barva, materiál atd. 
a zároveň metody jako Prodej(pocetKusu) 
či Naskladni(pocetKusu).

Dále udělej poděděné třídy, které budou odvozeny od 
základní a budou ji rozšiřovat o své především vlastnosti. 
Tedy např.: třída Mikina bude mít svoji vlastnost 
StylKapes, MaKapuci apod. Další třídou bude 
např.: Cepice a bude mít např.: vlastnosti MaBambuli, 
JeZimni apod.

Vytvoř si jednotlivé instance tříd a přidej je do nějaké 
kolekce. Udělej možnost volání prodeje položek 
a naskladnění položek. Pokus se udělat i počítání peněz, 
ať víš jak na tom tvuj e-shop je finančně :)

Položky samozřejmě nemusíš zadávat ručně, 
ale už umíme pracovat se souborem (soubory). 
A možná jsou i další vylepšení opět podle fantazie.

Uvedený příklad eshopu s oblečením ber, 
prosím jen jako možnost, určitě je možné udělat eshop 
na jiné téma.
*/

public class Program
{
    static List<Sperk> VystavZbozi (List<Sperk> polozkySkladu, List<Sperk> polozkyKProdeji)
    {
        for (int i = 0; i < polozkyKProdeji.Count; i++)
        {
            polozkyKProdeji.RemoveAt(i);
        }

        foreach (var item in polozkySkladu)
        {
            if (item.JeSkladem)
            {
                polozkyKProdeji.Add(item);
            }
        }
        Console.WriteLine("Vystavené zboží bylo aktualizováno");
        return polozkyKProdeji;
    }

    static void VypisPolozky(List<Sperk> listKVypsani)
    {
        foreach (var item in listKVypsani)
        {
            if (item is Nahrdelnik)
            {
                Nahrdelnik nahr = (Nahrdelnik)item;
                Console.WriteLine($"{nahr.DruhSperku}\t{nahr.Sku}\t{nahr.Kov}\t{nahr.RyzostKovu}\t{nahr.BarvaKovu}\t{nahr.Kamen}\t{nahr.HmotnostGramy}\t{nahr.Cena}\t{nahr.Obrazek}\t{nahr.CestaKObrazku}\t{nahr.JeSkladem}\t{nahr.Nazev}\t{nahr.Popis}\t{nahr.PocetKs}\t{nahr.DelkaNahrdelniku}");
            }
            if (item is Prsten)
            {
                Prsten prst = (Prsten)item;
                Console.WriteLine($"{prst.DruhSperku}\t{prst.Sku}\t{prst.Kov}\t{prst.RyzostKovu}\t{prst.BarvaKovu}\t{prst.Kamen}\t{prst.HmotnostGramy}\t{prst.Cena}\t{prst.Obrazek}\t{prst.CestaKObrazku}\t{prst.JeSkladem}\t{prst.Nazev}\t{prst.Popis}\t{prst.PocetKs}\t{prst.VelikostPrstenu}");
            }
            if (item is Naramek)
            {
                Naramek naram = (Naramek)item;
                Console.WriteLine($"{naram.DruhSperku}\t{naram.Sku}\t{naram.Kov}\t{naram.RyzostKovu}\t{naram.BarvaKovu}\t{naram.Kamen}\t{naram.HmotnostGramy}\t{naram.Cena}\t{naram.Obrazek}\t{naram.CestaKObrazku}\t{naram.JeSkladem}\t{naram.Nazev}\t{naram.Popis}\t{naram.PocetKs}\t{naram.DelkaNaramku}");
            }
            if (item is Nausnice)
            {
                Nausnice naus = (Nausnice)item;
                Console.WriteLine($"{naus.DruhSperku}\t{naus.Sku}\t{naus.Kov}\t{naus.RyzostKovu}\t{naus.BarvaKovu}\t{naus.Kamen}\t{naus.HmotnostGramy}\t{naus.Cena}\t{naus.Obrazek}\t{naus.CestaKObrazku}\t{naus.JeSkladem}\t{naus.Nazev}\t{naus.Popis}\t{naus.PocetKs}\t{naus.DruhZapinani}");
            }
            if (item is Privesek)
            {
                Privesek priv = (Privesek)item;
                Console.WriteLine($"{priv.DruhSperku}\t{priv.Sku}\t{priv.Kov}\t{priv.RyzostKovu}\t{priv.BarvaKovu}\t{priv.Kamen}\t{priv.HmotnostGramy}\t{priv.Cena}\t{priv.Obrazek}\t{priv.CestaKObrazku}\t{priv.JeSkladem}\t{priv.Nazev}\t{priv.PocetKs}\t{priv.PocetKs}\t{priv.TypPrivesku}");
            }
        }
    }

    static void Main(string[] args)
    {
        bool jeKonec = false;
        // položky skladu
        List<Sperk> polozkySkladu = new List<Sperk>(); 

        // položky, které mohou být prodávány (jeSkladem=true)
        List<Sperk> polozkyKProdeji = new List<Sperk>(); 

        // prodané položky, včetně počtu
        List<Sperk> prodanePolozky = new List<Sperk>(); 

        while (!jeKonec)
        {
            Console.WriteLine("ZÁKLADNÍ MENU:");
            Console.WriteLine("1-Administrace skladu");
            Console.WriteLine("2-Administrace Prodeje");
            Console.WriteLine("3-Nákup na eshopu");
            Console.WriteLine("0-Konec");
            Console.Write("Zadej volbu: ");

            int menu = Convert.ToInt32(Console.ReadLine());

            switch (menu)
            {
                case 0:
                    jeKonec = true;
                    break;
                case 1:
                    bool opustitAdministraci = false;
                    while (!opustitAdministraci)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("MENU ADMINISTRACE:");
                        Console.WriteLine("1-Přidání nové položky");
                        Console.WriteLine("2-Uložení položky do souboru");
                        Console.WriteLine("3-Načtení položek ze souboru");
                        Console.WriteLine("4-Naskladnění položky");
                        Console.WriteLine("5-Vystavení uložených položek na eshop k prodeji");
                        Console.WriteLine("0-Konec");
                        Console.Write("Zadej volbu: ");

                        int menuAdministrace = Convert.ToInt32(Console.ReadLine());

                        switch (menuAdministrace)
                        {
                            case 0:
                                Console.WriteLine("");
                                opustitAdministraci = true;
                                break;
                            case 1: //přidání nové položky
                                {
                                    bool zrusitZadavani = false;
                                    while (!zrusitZadavani)
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Vyber druh šperku:");
                                        Console.WriteLine("1-Náhrdelník");
                                        Console.WriteLine("2-Náramek");
                                        Console.WriteLine("3-Prsten");
                                        Console.WriteLine("4-Náušnice");
                                        Console.WriteLine("5-Přívěsek");
                                        Console.WriteLine("0-Ukončit zadávání");
                                        Console.Write("Zadej volbu: ");

                                        int druhSperku = Convert.ToInt32(Console.ReadLine());
                                        if (druhSperku == 0)
                                        {
                                            Console.WriteLine("");
                                            zrusitZadavani = true;
                                            break;

                                        }
                                        // ověřit unikátnost SKU
                                        Console.Write("Zadej unikátní SKU: ");
                                        string sku = Console.ReadLine();

                                        Console.Write("Zadej kov: ");
                                        string kov = Console.ReadLine();
                                        Console.Write("Zadej ryzost kovu: ");
                                        string ryzostKovu = Console.ReadLine();
                                        Console.Write("Zadej barvu kovu: ");
                                        string barvaKovu = Console.ReadLine();
                                        Console.Write("Zadej kámen: ");
                                        string kamen = Console.ReadLine();
                                        Console.Write("Zadej hmotnost [g]: ");
                                        double hmotnostGramy = Convert.ToDouble(Console.ReadLine());
                                        Console.Write("Zadej cenu [Kč]: ");
                                        double cena = Convert.ToDouble(Console.ReadLine());
                                        Console.Write("Zadej název obrázku včetně přípony: ");
                                        string obrazek = Console.ReadLine();
                                        Console.Write("Zadej cestu k obrázku: ");
                                        string cestaKObrazku = Console.ReadLine();
                                        Console.Write("Zadej název šperku: ");
                                        string nazev = Console.ReadLine();
                                        Console.Write("Zadej popis šperku: ");
                                        string popis = Console.ReadLine();
                                        Console.Write("Zadej počet [ks]: ");
                                        int pocetKs = Convert.ToInt32(Console.ReadLine());
                                        bool jeSkladem = false;

                                        if (pocetKs > 0)
                                        {
                                            jeSkladem = true;
                                        }


                                        switch (druhSperku)
                                        {
                                            case 0:
                                                Console.WriteLine("");
                                                zrusitZadavani = true;
                                                break;
                                            case 1:
                                                Console.Write("Zadej délku náhrdelníku [cm]: ");
                                                int delkaNahrdelniku = Convert.ToInt32(Console.ReadLine());
                                                Nahrdelnik nahrdelnik = new Nahrdelnik("Náhrdelník", sku, kov, ryzostKovu, barvaKovu, kamen, hmotnostGramy, cena, obrazek, cestaKObrazku, jeSkladem, nazev, popis, pocetKs, delkaNahrdelniku);
                                                polozkySkladu.Add(nahrdelnik);
                                                Console.WriteLine("Položka přidána");
                                                break;
                                            case 2:
                                                Console.Write("Zadej délku náramku [cm]: ");
                                                int delkaNaramku = Convert.ToInt32(Console.ReadLine());
                                                Naramek naramek = new Naramek("Náramek", sku, kov, ryzostKovu, barvaKovu, kamen, hmotnostGramy, cena, obrazek, cestaKObrazku, jeSkladem, nazev, popis, pocetKs, delkaNaramku);
                                                polozkySkladu.Add(naramek);
                                                Console.WriteLine("Položka přidána");
                                                break;
                                            case 3:
                                                Console.Write("Zadej velikost prstenu [mm]: ");
                                                int velikostPrstenu = Convert.ToInt32(Console.ReadLine());
                                                Prsten prsten = new Prsten("Prsten", sku, kov, ryzostKovu, barvaKovu, kamen, hmotnostGramy, cena, obrazek, cestaKObrazku, jeSkladem, nazev, popis, pocetKs, velikostPrstenu);
                                                polozkySkladu.Add(prsten);
                                                Console.WriteLine("Položka přidána");
                                                break;
                                            case 4:
                                                Console.Write("Zadej druh zapínání náušnic: ");
                                                string druhZapinani = Console.ReadLine();
                                                Nausnice nausnice = new Nausnice("Náušnice", sku, kov, ryzostKovu, barvaKovu, kamen, hmotnostGramy, cena, obrazek, cestaKObrazku, jeSkladem, nazev, popis, pocetKs, druhZapinani);
                                                polozkySkladu.Add(nausnice);
                                                Console.WriteLine("Položka přidána");
                                                break;
                                            case 5:
                                                Console.Write("Zadej typ přívěsku: ");
                                                string typPrivesku = Console.ReadLine();
                                                Privesek privesek = new Privesek("Přívěsek", sku, kov, ryzostKovu, barvaKovu, kamen, hmotnostGramy, cena, obrazek, cestaKObrazku, jeSkladem, nazev, popis, pocetKs, typPrivesku);
                                                polozkySkladu.Add(privesek);
                                                Console.WriteLine("Položka přidána");
                                                break;

                                        }
                                    }

                                    break;
                                }
                            case 2: // Uložení do souboru
                                {
                                    string cesta1Ulozeno = "C:\\Users\\macha\\OneDrive\\C#2\\Domácí úkoly\\Ukol7Eshop\\ulozeno1.txt";
                                    //string cestaDatabaze = "C:\\Users\\macha\\OneDrive\\C#2\\Domácí úkoly\\Ukol7Eshop\\databaze.txt";
                                    StringBuilder builder = new StringBuilder();
                                    foreach (var item in polozkySkladu)
                                    {
                                        if (item is Nahrdelnik)
                                        {
                                            Nahrdelnik nahr = (Nahrdelnik)item;
                                            builder.AppendLine($"{nahr.DruhSperku}\t{nahr.Sku}\t{nahr.Kov}\t{nahr.RyzostKovu}\t{nahr.BarvaKovu}\t{nahr.Kamen}\t{nahr.HmotnostGramy}\t{nahr.Cena}\t{nahr.Obrazek}\t{nahr.CestaKObrazku}\t{nahr.JeSkladem}\t{nahr.Nazev}\t{nahr.Popis}\t{nahr.PocetKs}\t{nahr.DelkaNahrdelniku}");
                                        }
                                        if (item is Prsten)
                                        {
                                            Prsten prst = (Prsten)item;
                                            builder.AppendLine($"{prst.DruhSperku}\t{prst.Sku}\t{prst.Kov}\t{prst.RyzostKovu}\t{prst.BarvaKovu}\t{prst.Kamen}\t{prst.HmotnostGramy}\t{prst.Cena}\t{prst.Obrazek}\t{prst.CestaKObrazku}\t{prst.JeSkladem}\t{prst.Nazev}\t{prst.Popis}\t{prst.PocetKs}\t{prst.VelikostPrstenu}");
                                        }
                                        if (item is Naramek)
                                        {
                                            Naramek naram = (Naramek)item;
                                            builder.AppendLine($"{naram.DruhSperku}\t{naram.Sku}\t{naram.Kov}\t{naram.RyzostKovu}\t{naram.BarvaKovu}\t{naram.Kamen}\t{naram.HmotnostGramy}\t{naram.Cena}\t{naram.Obrazek}\t{naram.CestaKObrazku}\t{naram.JeSkladem}\t{naram.Nazev}\t{naram.Popis}\t{naram.PocetKs}\t{naram.DelkaNaramku}");
                                        }
                                        if (item is Nausnice)
                                        {
                                            Nausnice naus = (Nausnice)item;
                                            builder.AppendLine($"{naus.DruhSperku}\t{naus.Sku}\t{naus.Kov}\t{naus.RyzostKovu}\t{naus.BarvaKovu}\t{naus.Kamen}\t{naus.HmotnostGramy}\t{naus.Cena}\t{naus.Obrazek}\t{naus.CestaKObrazku}\t{naus.JeSkladem}\t{naus.Nazev}\t{naus.Popis}\t{naus.PocetKs}\t{naus.DruhZapinani}");
                                        }
                                        if (item is Privesek)
                                        {
                                            Privesek priv = (Privesek)item;
                                            builder.AppendLine($"{priv.DruhSperku}\t{priv.Sku}\t{priv.Kov}\t{priv.RyzostKovu}\t{priv.BarvaKovu}\t{priv.Kamen}\t{priv.HmotnostGramy}\t{priv.Cena}\t{priv.Obrazek}\t{priv.CestaKObrazku}\t{priv.JeSkladem}\t{priv.Nazev}\t{priv.PocetKs}\t{priv.PocetKs}\t{priv.TypPrivesku}");
                                        }
                                    }


                                    string zadanyText = builder.ToString();
                                    if (File.Exists(cesta1Ulozeno))
                                    {
                                        File.WriteAllText(cesta1Ulozeno, zadanyText);
                                        Console.WriteLine("Vše uloženo");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Soubor neexistuje, neuloženo!");
                                    }
                                    
                                    break;
                                }
                            case 3: // Načtení položek ze souboru
                                {
                                    // cestaDatabaze;
                                    Console.WriteLine("Zatím nejsem naprogramován");
                                    break;
                                }
                            case 4: //Naskladnění položky
                                {
                                    Console.Write("Zadej SKU produktu k naskladnění: ");
                                    string sku = Console.ReadLine();
                                    Console.Write("Zadej Počet kusů: ");
                                    int pocet = Convert.ToInt32(Console.ReadLine());

                                    foreach (var item in polozkySkladu)
                                    {
                                        if (string.Equals(item.Sku, sku, StringComparison.OrdinalIgnoreCase))
                                        {
                                            Console.WriteLine(item.Naskladni(pocet));
                                        }
                                    }
                                    polozkyKProdeji = VystavZbozi(polozkySkladu, polozkyKProdeji);
                                    break;
                                }
                            case 5: //Vystavení uložených položek na eshop k prodeji
                                {
                                    polozkyKProdeji = VystavZbozi(polozkySkladu, polozkyKProdeji);
                                    break;
                                }



                        }
                    }
                    break;
                case 2:
                    bool opustitAdminProdeje = false;
                    while (!opustitAdminProdeje)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("PRODEJ ADMINISTRACE: ");
                        Console.WriteLine("1-Prodané položky");
                        Console.WriteLine("2-Hodnota prodaných položek");
                        Console.WriteLine("3-Hodnota skladu");
                        Console.WriteLine("0-Konec");
                        Console.Write("Zadej volbu: ");

                        int menuAdminProdeje = Convert.ToInt32(Console.ReadLine());

                        switch (menuAdminProdeje)
                        {
                            case 0:
                                Console.WriteLine("");
                                opustitAdminProdeje = true;
                                break;
                            case 1: // Prodané položky
                                {
                                    //Console.WriteLine("Zatím nejsem naprogramován");
                                    if (prodanePolozky.Count > 0)
                                    {
                                        VypisPolozky(prodanePolozky);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Zatím nebylo nic prodáno.");
                                    }
                                    
                                    break;
                                }
                            case 2: // Hodnota prodaných položek
                                {
                                    //Console.WriteLine("Zatím nejsem naprogramován");
                                    double hodnotaPP = 0;
                                    if (prodanePolozky.Count > 0)
                                    {
                                        foreach (var item in prodanePolozky)
                                        {
                                            hodnotaPP = hodnotaPP + (item.Cena * item.PocetKs);
                                        }
                                        Console.WriteLine("Hodnota prodaných položek: " + hodnotaPP);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Zatím nebylo nic prodáno.");
                                    }

                                    break;
                                }
                            case 3: // Hodnota skladu
                                {
                                    //Console.WriteLine("Zatím nejsem naprogramován");
                                    double hodnotaSkladu = 0;
                                    foreach (var item in polozkySkladu)
                                    {
                                        hodnotaSkladu = hodnotaSkladu + item.Cena * item.PocetKs;
                                    }
                                    Console.WriteLine("Hodnota skladu: " + hodnotaSkladu);
                                    break;
                                }

                        }
                    }
                    break;
                case 3:
                    bool opustitEshop = false;
                    while (!opustitEshop)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("E-SHOP:");
                        Console.WriteLine("1-Zobrazení dostupných položek");
                        Console.WriteLine("2-Koupit položku");
                        Console.WriteLine("0-Konec");
                        Console.Write("Zadej volbu: ");

                        int menuEshop = Convert.ToInt32(Console.ReadLine());

                        switch (menuEshop)
                        {
                            case 0:
                                Console.WriteLine("");
                                opustitEshop = true;
                                break;
                            case 1: // Zobrazení dostupných položek
                                {
                                    //Console.WriteLine("Zatím nejsem naprogramován");
                                    
                                    VypisPolozky(polozkyKProdeji);
                                    break;
                                }
                            case 2: // Koupit položku
                                {
                                    //Console.WriteLine("Zatím nejsem naprogramován");
                                    Console.Write("Zadej SKU produktu: ");
                                    string sku = Console.ReadLine();
                                    Console.Write("Zadej Počet kusů: ");
                                    int pocet = Convert.ToInt32(Console.ReadLine());

                                    foreach (var item in polozkySkladu)
                                    {
                                        if (string.Equals(item.Sku, sku, StringComparison.OrdinalIgnoreCase))
                                        {
                                            Sperk prodano = item;
                                            prodano.PocetKs = pocet;

                                            if (item.PocetKs > pocet)
                                            {
                                                prodanePolozky.Add(prodano);

                                                Console.WriteLine(item.Prodej(pocet));
                                            }
                                            else if (item.PocetKs == pocet)
                                            {
                                                prodanePolozky.Add(prodano);
                                                Console.WriteLine(item.Prodej(pocet));
                                                item.JeSkladem = false;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Na skladě není dostatečný počet kusů.");
                                            }

                                        }
                                    }
                                    polozkyKProdeji = VystavZbozi(polozkySkladu, polozkyKProdeji);
                                    break;

                                }


                        }
                    }
                    break;

            }
        }
}}
