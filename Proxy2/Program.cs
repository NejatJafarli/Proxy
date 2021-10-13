using System;

namespace Proxy2
{
    //protected Proxy
    interface IBanka
    {
        bool OdemeYap(double Tutar);
    }

    class Banka : IBanka
    {
        public bool OdemeYap(double Tutar)
        {
            if (Tutar < 100)
                Console.WriteLine($"Ödeyeceğiniz tutar 100 TL'den az olamaz. Fark -> { 100 - Tutar }");
            else if (Tutar > 100)
                Console.WriteLine($"Ödeyeceğiniz tutar 100 TL'den fazla olamaz. Fark -> { Tutar - 100 }");
            else
            {
                Console.WriteLine($"Ödeme başarıyla gerçekleştirildi. -> { Tutar }");
                return true;
            }

            return false;
        }
    }
    class ProxyBanka : IBanka
    {
        Banka banka;


        bool Login;
        string KullaniciAdi, Sifre;
        public ProxyBanka(string KullaniciAdi, string Sifre)
        {
            this.KullaniciAdi = KullaniciAdi;
            this.Sifre = Sifre;
        }

        bool GirisYap()
        {
            if (KullaniciAdi.Equals("nicat") && Sifre.Equals("nicat"))
            {

                //Protected Proxy Start
                banka = new Banka();
                Login = true;
                Console.WriteLine("Hesaba giriş yapıldı.");
                return true;
            }
            else
                Console.WriteLine("Lütfen kullanıcı adı ve şifreinizi doğru girdiğinize emin olunuz.");

            Login = false;
            return false;
        }

        public bool OdemeYap(double Tutar)
        {
            GirisYap();

            if (!Login)
            {
                Console.WriteLine("Hesaba giriş yapılmadığından dolayı ödeme alamıyoruz.");
                return false;
            }

            banka.OdemeYap(Tutar);
            return true;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            string KullaniciAdi = "", Sifre = "";
            double Tutar = 0;
            while (true)
            {
                Console.WriteLine("Lütfen kullanıcı adınızı giriniz.");
                KullaniciAdi = Console.ReadLine();

                Console.WriteLine("Lütfen şifrenizi giriniz.");
                Sifre = Console.ReadLine();

                Console.WriteLine("Lütfen ödenecek miktarı giriniz.");
                Tutar = Convert.ToInt32(Console.ReadLine());

                IBanka banka = new ProxyBanka(KullaniciAdi, Sifre);
                banka.OdemeYap(Tutar);

                Console.WriteLine("************");
            }
        }
    }
}
