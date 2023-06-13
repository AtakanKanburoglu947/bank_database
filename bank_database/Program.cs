// See https://aka.ms/new-console-template for more information

using bank_database;
using Microsoft.Data.SqlClient;



Console.WriteLine("Veritabanı sunucusu: ");
string? dataSource = Console.ReadLine();

Config Config = new Config(dataSource);
Config.connection?.Open();

Console.WriteLine("Bankamıza hoş geldiniz.");

Console.WriteLine("Kimlik numaranızı giriniz.");
string? kimlik = Console.ReadLine();
Console.WriteLine("Şifrenizi giriniz.");
string? sifre = Console.ReadLine();
SqlCommand command = new SqlCommand(Queries.queries[0], Config.connection);
command.Parameters.AddWithValue("@Sifre", sifre);
command.Parameters.AddWithValue("@KimlikNo", kimlik);
SqlDataReader reader = command.ExecuteReader();
command.Parameters.Clear();

if (reader.Read())
{
    int musteriId = Convert.ToInt32(reader.GetValue(0));
    Config.connection?.Close();
    Console.WriteLine("\n Giriş başarılı.");
    while (true)
    {
        Console.WriteLine("\n İşlemler: \n" +
     " 1) Sahip olduğunuz kredi kartları ve bilgileri \n 2) Hesap bilgileri \n 3) Yapılan harcamalar \n" +
     " 4) Para yükleme \n 5) Harcama yapın \n 6) Şubeler hakkında bilgiler " +
     " 7) Çalışanlarımız \n 8) Bölge müdürlükleri hakkında bilgiler \n 9) Borsa \n 10) Yöneticilerimiz \n 11) Çıkış ");

        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case (int)Choice.Cards:

                Config.connection?.Open();
                command = new SqlCommand(Queries.queries[1], Config.connection);
                command.Parameters.AddWithValue("@MusteriID", musteriId);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("Kalan nakit: " + reader.GetValue(0) + " " + " Kart numarası: " + reader.GetValue(1) + " " + " Son kullanım tarihi: " + reader.GetValue(2) +
                        " Güvenlik numarası: " + reader.GetValue(3) + " IBAN: " + reader.GetValue(4) + " Şube adresi: " + reader.GetValue(5) + " " + reader.GetValue(6) + " Şubesi");
                }
                command.Parameters.Clear();
                Config.connection?.Close();

                break;

            case (int)Choice.AccountInfo:

                Config.connection?.Open();
                command = new SqlCommand(Queries.queries[2], Config.connection);
                command.Parameters.AddWithValue("@MusteriID", musteriId);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("Ad: " + reader.GetValue(0) + " " + " Soyad: " + reader.GetValue(1) + " " + " Şifre: " + reader.GetValue(2) +
                        " Kimlik numarası: " + reader.GetValue(3) + " Telefon numarası: " + reader.GetValue(4));
                }
                command.Parameters.Clear();
                Config.connection.Close();
                break;
            case (int)Choice.Spendings:
                Config.connection?.Open();
                command = new SqlCommand(Queries.queries[7], Config.connection);
                command.Parameters.AddWithValue("@MusteriID", musteriId);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Harcanılan miktar: {reader.GetValue(0)} {reader.GetValue(1)}");
                }
                command.Parameters.Clear();
                Config.connection?.Close();
                break;
            case (int)Choice.Deposit:
                Config.connection?.Open();
                command = new SqlCommand(Queries.queries[8], Config.connection);
                Console.WriteLine("Yüklenecek para miktarı: ");
                int para = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Kart ID: ");
                int kartId = Convert.ToInt32(Console.ReadLine());
                command.Parameters.AddWithValue("@Para", para);
                command.Parameters.AddWithValue("@MusteriID", musteriId);
                command.Parameters.AddWithValue("@KartID", kartId);
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                Config.connection?.Close();

                Console.WriteLine("Para yükleme işleme başarıyla tamamlandı.");
                break;
            case (int)Choice.Spend:
                Config.connection?.Open();
                command = new SqlCommand(Queries.queries[9], Config.connection);
                Console.WriteLine("Harcanilcak para miktarı: ");
                int harcanilcakPara = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Kart ID: ");
                int kartNumarasi = Convert.ToInt32(Console.ReadLine());
                command.Parameters.AddWithValue("@Para", harcanilcakPara);
                command.Parameters.AddWithValue("@MusteriID", musteriId);
                command.Parameters.AddWithValue("@KartID", kartNumarasi);
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                Config.connection?.Close();
                Console.WriteLine("Para harcama işlemi başarıyla tamamlanmıştır.");
                break;

            case (int)Choice.Branches:
                Config.connection?.Open();
                command = new SqlCommand(Queries.queries[3], Config.connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Adres: {reader.GetValue(0)} Şube telefon numarası: {reader.GetValue(1)} " +
                        $"İl: {reader.GetValue(2)} İlçe: {reader.GetValue(3)} Şube yöneticisinin adı: {reader.GetValue(4)} Şube yöneticisinin soyadı: {reader.GetValue(5)}" +
                        $" Şube yöneticisinin telefon numarası: {reader.GetValue(6)}   ");
                }
                Config.connection?.Close();
                break;
            case (int)Choice.Employees:
                Config.connection?.Open();
                command = new SqlCommand(Queries.queries[4], Config.connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Ad: {reader.GetValue(0)} Soyad: {reader.GetValue(1)} " +
                        $"Telefon numarası: {reader.GetValue(2)} Rolü: {reader.GetValue(3)} Mezun olduğu bölüm: {reader.GetValue(4)} Şubesi : {reader.GetValue(5)}");
                }
                Config.connection?.Close();
                break;
            case (int)Choice.RegionalDirectorates:
                Config.connection?.Open();   
                command = new SqlCommand(Queries.queries[5], Config.connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Bölge: {reader.GetValue(0)} Adres: {reader.GetValue(1)} Telefon numarası: {reader.GetValue(2)} Şubeler: {reader.GetValue(3)} ");
                }
                Config.connection?.Close();
                break;
            case (int)Choice.ExchangeRates:
                Config.connection?.Open();
                command = new SqlCommand(Queries.queries[6], Config.connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Döviz cinsi: {reader.GetValue(0)} Alış fiyatı: {reader.GetValue(1)} Satış fiyatı: {reader.GetValue(2)}");
                }
                Config.connection?.Close();
                break;
            case (int)Choice.Managers:
                Config.connection?.Open();
                command = new SqlCommand(Queries.queries[10], Config.connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Ad: {reader.GetValue(0)} Soyad: {reader.GetValue(1)} Telefon numarası: {reader.GetValue(2)} ");
                }
                Config.connection?.Close();
                break;
            case (int)Choice.Exit:
                return;
        }
    }


}
else
{
    Console.WriteLine("Giriş başarısız.");
}
