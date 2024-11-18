using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Bir şirket birden fazla çalışana sahip olabilir ve her çalışanın bir şirketi vardır.
class Şirket
{
    public string Ad { get; private set; }
    public string Konum { get; private set; }
    public List<Calısan> Calısanlar { get; set; }
    public Şirket(string ad, string konum)
    {
        Ad = ad;
        Konum = konum;
        Calısanlar = new List<Calısan>();
    }
    public void CalısanEkle(Calısan calısan)
    {
        Calısanlar.Add(calısan);
    }
    public string ŞirketBilgieri()
    {
        return $"Şirketin Adı: {Ad}\nKonumu: {Konum}\n";
    }
    public void Yaz()
    {
        Console.WriteLine(ŞirketBilgieri());
        foreach (var calısan in Calısanlar)
        {
            Console.WriteLine($"Hastanın adı: {calısan.CalısanAd}\nHastanın TcNosu: {calısan.Tc}");
        }
        Console.WriteLine("\n");

    }
}
class Calısan
{
    public string CalısanAd { get; private set; }
    private string TCNo;
    public Şirket Şirket { get; private set; }
    public string Tc
    {
        get { return TCNo; }
        set
        {
            if (value.Length == 11)
            { TCNo = value; }
            else { Console.WriteLine("HATA!!,TC kimlik numaranız 11 karakterli olmak zorundadır"); }
        }
    }


    public Calısan(string ad, string tc)
    {
        CalısanAd = ad;
        Tc = tc;

    }

    public void ŞirketAtama(Şirket şirket)
    {
        int flag = 0;
        for (int i = 0; i < şirket.Calısanlar.Count; i++)
        {
            if (şirket.Calısanlar[i] != (this))
            {
                flag = 1;
            }
        }
        if (flag == 0)
        {
            şirket.CalısanEkle(this);
        }
        else
        {
            Console.WriteLine("BU ÇALIŞAN BAŞKA BİR ŞİRKETTE KAYITLI");
        }

    }
}
class Program
{
    static void Main(string[] args)
    {
        Şirket şirket1 = new("şİRKET", "İSTANBUL");
        Şirket şirket2 = new("Kesen", "MALATYA");
        Şirket şirket3 = new("ŞİRKET78", "KARABUK");
        Calısan calısan1 = new("Berat Kama", "15423078541");
        Calısan calısan2 = new("Yusuf Tuncel", "12345678915");
        Calısan calısan3 = new("Abdullah Dağ", "11025476235");
        şirket1.CalısanEkle(calısan3);
        şirket2.CalısanEkle(calısan2);
        calısan1.ŞirketAtama(şirket2);
        şirket3.CalısanEkle(calısan1);
        calısan2.ŞirketAtama(şirket1);
        şirket1.Yaz();
        şirket2.Yaz();
        şirket3.Yaz();


    }
}