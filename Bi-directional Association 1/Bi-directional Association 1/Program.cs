using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Bir doktor birden fazla hastaya sahip olabilir ve her hasta bir doktora bağlıdır.
class Doktor
{
    public string Ad { get; private set; }
    public string Brans { get; private set; }
    public List<Hasta> Hastalar { get; set; }
    public Doktor (string ad, string brans)
    {
        Ad = ad;
        Brans = brans;
        Hastalar = new List<Hasta> ();
    }
    public void HastaEkle(Hasta hasta)
    {
            Hastalar.Add(hasta); 
    }
    public string DoktorBilgieri() 
    {
        return $"Doktorun Adı: {Ad}\nBranşı: {Brans}\n";
    }
    public void Yaz()
    {   
        Console.WriteLine(DoktorBilgieri());
        foreach (var hasta in Hastalar) 
        {
            Console.WriteLine($"Hastanın adı: {hasta.HastaAd}\nHastanın TcNosu: {hasta.Tc}");
        }
        Console.WriteLine("\n");
       
    }
}
class Hasta
{
    public string HastaAd { get; private set; }
    private string TCNo;
    public Doktor Doktor { get; private set; }
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


    public Hasta(string ad, string tc)
    {
        HastaAd = ad;
        Tc = tc;

    }
    
    public void DoktorAtama(Doktor doktor)
    {
        int flag = 0;
        for (int i = 0; i < doktor.Hastalar.Count; i++)
        {
            if (doktor.Hastalar[i]!= (this))
            {
                flag = 1;
            }
        }
        if (flag == 0)
        {
            doktor.HastaEkle(this);
        }
        else
        {
            Console.WriteLine("BU HASTA BAŞKA BİR DOKTORA KAYITLI");
        }

    }
}
class Program
{
    static void Main(string[] args)
    {
        Doktor doktor1 = new("Alex De Souza", "Kardiyoloji");
        Doktor doktor2 = new("Beşir Kesen", "Ortopedi");
        Doktor doktor3 = new("Ahmet Kesen", "KBB");
        Hasta hasta1 = new("Berat Kama", "15423078541");
        Hasta hasta2 = new("Yusuf Tuncel", "12345678915");
        Hasta hasta3 = new("Abdullah Dağ", "11025476235");
        doktor1.HastaEkle(hasta3);
        doktor2.HastaEkle(hasta2);
        hasta1.DoktorAtama(doktor2);
        doktor3.HastaEkle(hasta1);
        hasta2.DoktorAtama(doktor1);
        doktor1.Yaz();
        doktor2.Yaz();
        doktor3.Yaz();


    }
}