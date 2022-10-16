using CurrentAccount.Models;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using Npgsql;

namespace CurrentAccount.Data
{
    public class Connector
    {
        NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=CurrentAccountDB;User ID=postgres;Password=postgres;");

        public void CariHesapEkle(CariHesap cariHesap)
        {
            connection.Query<CariHesap>("Insert Into \"CariHesap\" (ad) Values (@ad)", cariHesap);
        }
        public List<CariHesap> CariHesapListeGetir()
        {
            var CariHesaplar = connection.Query<CariHesap>("Select * from \"CariHesap\"");
            return CariHesaplar?.ToList();
        }

        public void HesapFisEkle(HesapFis hesapFis)
        {
            connection.Query<HesapFis>(
            "Insert Into \"HesapFis\" (\"cariHesapId\", tarih, alacak, borc, bakiye) Values (@cariHesapId, @tarih, @alacak, @borc, @bakiye)", hesapFis
            );
        }
        public List<HesapFis> HesapFisFiltrele(int cariHesapId)
        {
            var hesapFisler = connection.Query<HesapFis>("Select * From \"HesapFis\" Where \"cariHesapId\"=@cariHesapId", new { cariHesapId=cariHesapId});
            return hesapFisler.ToList();
        }

    }
}
