using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Bir ebeveynin birden fazla çocuğu olabilir ve her çocuk bir ebeveynle ilişkilidir.
class Evebeyn
{
    public string Ad { get; private set; }
    public int Yas { get; private set; }
    public List<Cocuk> Cocuklar { get; set; }
    public Evebeyn(string ad, int yas)
    {
        Ad = ad;
        Yas = yas;
        Cocuklar = new List<Cocuk>();
    }
    public void CocukEkle(Cocuk cocuk)
    {
        Cocuklar.Add(cocuk);
    }
    public string EvebeynBilgieri()
    {
        return $"Evebeynin Adı: {Ad}\nYaşı: {Yas}\n";
    }
    public void Yaz()
    {
        Console.WriteLine(EvebeynBilgieri());
        foreach (var cocuk in Cocuklar)
        {
            Console.WriteLine($"COCUGUN ADI : {cocuk.CocukAd}\nCOCUGUN YASI: {cocuk.Yas}");
        }
        Console.WriteLine("\n");

    }
}
class Cocuk
{
    public string CocukAd { get; private set; }
    public int Yas { get; private set; }
    public Evebeyn Evebeyn { get; private set; }
    public Cocuk(string ad, int yas)
    {
        CocukAd = ad;
        Yas = yas;
    }

    public void EvebeynAtama(Evebeyn evebeyn)
    {
        int flag = 0;
        for (int i = 0; i < evebeyn.Cocuklar.Count; i++)
        {
            if (evebeyn.Cocuklar[i] != (this))
            {
                flag = 1;
            }
        }
        if (flag == 0)
        { 
            evebeyn.CocukEkle(this);
        }
        else
        {
            Console.WriteLine("BU COCUK BAŞKA BİR EVEBEYNE AİT");
        }

    }
}
class Program
{
    static void Main(string[] args)
    {
        Evebeyn evebeyn1 = new("Beşir",28);
        Evebeyn evebeyn2 = new("Kesen", 45);
        Cocuk cocuk1 = new("Berat",5);
        Cocuk cocuk2 = new("Yusuf",7);
        Cocuk cocuk3 = new("Abdullah", 12);
        evebeyn1.CocukEkle(cocuk3);
        evebeyn2.CocukEkle(cocuk2);
        evebeyn1.CocukEkle(cocuk1);
        cocuk1.EvebeynAtama(evebeyn1);
        evebeyn1.Yaz();
        evebeyn2.Yaz();


    }
}