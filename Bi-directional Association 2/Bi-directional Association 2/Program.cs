using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Bir yazar birden fazla kitap yazabilir ve her kitap bir yazarla ilişkilidir.
class Yazar
{
    public string Ad { get; private set; }
    public string Ulke { get; private set; }
    public List<Kitap> Kitaplar { get; private set; }
    public Yazar(string ad, string  ulke)
    {
        Ad = ad;
        Ulke = ulke;
        Kitaplar = new List<Kitap>();
    }
    public void KitapEkle(Kitap kitap) 
    {
        Kitaplar.Add(kitap);
    }
    public string YazarBilgileri()
    {
        return $"ADI: {Ad}\nULKESİ: {Ulke}";
    }
    public void Yaz()
    {
        Console.WriteLine(YazarBilgileri());
        foreach (var kitap in Kitaplar)
        {
            Console.WriteLine( $"Kitabın Başlığı: {kitap.Baslik}\nKitabın Yayın Yılı: {kitap.YayinYili}");
        }
        Console.WriteLine("\n");

    }
}
class Kitap
{
    public string Baslik { get;  private set; }
    public DateTime YayinYili { get; private set; }
    public Yazar Yazar { get; private set; }
    public Kitap(string baslik ,DateTime dateTime)
    {
        Baslik = baslik;
        YayinYili = dateTime;
    }

    public void YazarAtama(Yazar yazar)
    {
        int flag = 0;
        for (int i = 0; i < yazar.Kitaplar.Count; i++)
        {
            if (yazar.Kitaplar[i] != (this))
            {
                flag = 1;
            }
            
        }
        if (flag == 0)
        {
            yazar.KitapEkle(this);
        }
        else
        {
            Console.WriteLine("BU KİTAP BAŞKA YAZARA AİT ");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        DateTime dateTime1 = new DateTime(2005, 05, 05);
        DateTime dateTime2 = new DateTime(1998, 05, 05);
        DateTime dateTime3 = new DateTime(2021, 05, 05);
        DateTime dateTime4 = new DateTime(1880, 05, 05);
        Yazar yazar1 = new("Beşir Kesen", "Türkiye");
        Yazar yazar2 = new("Ahmet Kesen", "Türkiye");
        Kitap kitap1 = new("Sefiller",dateTime1);
        Kitap kitap2 = new("Dönüşüm", dateTime2);
        Kitap kitap3 = new("Hayatt Ve Ben", dateTime3);
        Kitap kitap4 = new("Öyleli", dateTime4);
        yazar1.KitapEkle(kitap4);
        yazar1.KitapEkle(kitap3);
        yazar2.KitapEkle(kitap2);
        yazar2.KitapEkle(kitap1);
        kitap1.YazarAtama(yazar1);
        yazar1.Yaz();
        yazar2.Yaz();

    }
}