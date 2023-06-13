using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_database
{
    internal static class Queries
    {
        internal static string[] queries =
        {
            "select * from Musteriler WHERE EXISTS (SELECT Sifre,KimlikNo FROM Musteriler WHERE Sifre = @Sifre AND KimlikNo = @KimlikNo)",
            "select Nakit,KartNo,SonKullanimTarihi,GuvenlikNo,IBAN,Adres,Il from Kartlar JOIN Subeler ON Kartlar.SubeID = Subeler.SubeID where Kartlar.MusteriID = @MusteriID",
            "select Ad,Soyad,Sifre,KimlikNo,TelefonNo from Musteriler where MusteriID = @MusteriID",
            "select Adres,Subeler.TelefonNo,Il,Ilce,Ad,Soyad,Yoneticiler.TelefonNo from Subeler  JOIN Yoneticiler ON Subeler.SubeID = Yoneticiler.YoneticiID",
            "select Ad,Soyad,Calisanlar.TelefonNo,Rol,BolumAdi,Il from Calisanlar JOIN Bolumler ON Calisanlar.BolumID = Bolumler.BolumID join Subeler on Calisanlar.SubeID = Subeler.SubeID",
            "select Bolge,BolgeMudurlukleri.Adres,BolgeMudurlukleri.TelefonNo,Subeler.Il from BolgeMudurlukleri JOIN Subeler ON BolgeMudurlukleri.BolgeMudurluguID = Subeler.BolgeMudurluguID",
            "select DovizCinsi,AlisFiyati,SatisFiyati from Borsa",
            "select Miktar,Aciklama from Harcamalar join Kartlar on Harcamalar.KartID = Kartlar.KartID join Musteriler on Musteriler.MusteriID = Kartlar.MusteriID where Musteriler.MusteriID = @MusteriID",
            "update Kartlar set Nakit = Nakit + @Para where MusteriID = @MusteriID and KartID = @KartID",
            "update Kartlar set Nakit = Nakit - @Para where MusteriID = @MusteriID and KartID = @KartID insert into Harcamalar(Miktar,Aciklama,KartID) values (@Para,'OrnekAciklama',@KartID)",
            "Select Ad,Soyad,TelefonNo from Yoneticiler"
        };
    }
}
