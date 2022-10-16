using CurrentAccount.Data;
using CurrentAccount.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurrentAccount.Controllers
{
    public class HomeController : Controller
    {
        private Connector _connection;

        public HomeController()
        {
            _connection = new Connector();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HesapEkle()
        {
            return View();
        }
        public IActionResult HesapFisEkle()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CariHesapEkle([FromBody] CariHesap cariHesap)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    status = "error",
                    message = "Girilen bilgileri kontrol ediniz."
                });
            }
            _connection.CariHesapEkle(cariHesap);
            return Json(new {
                status="success",
                message="Başarıyla oluşturuldu."
            });
        }
        public JsonResult CariHesapListe()
        {
            var cariHesaplar = _connection.CariHesapListeGetir();
            if(cariHesaplar.Count > 0)
            {
                return Json(new {
                    status = "success",
                    data = cariHesaplar
                });
            }
            return Json(new { 
                status = "error",
                message = "Herhangi bir kayıt bulunamadı."
            });
        }
        [HttpPost]
        public JsonResult HesapFisEkle([FromBody] HesapFisForm hesapFisForm)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    status = "error",
                    message = "Girilen bilgileri kontrol ediniz."
                });
            }

            HesapFis hesapFis = new HesapFis();
            float bakiye = 0;

            if (hesapFisForm.alacakBorc != "borc")
            {
                hesapFis.alacak = hesapFisForm.tutar;
                hesapFis.borc = 0;

                bakiye += hesapFisForm.tutar;
            }
            else
            {
                hesapFis.alacak = 0;
                hesapFis.borc = hesapFisForm.tutar;

                bakiye -= hesapFisForm.tutar;
            }

            hesapFis.cariHesapId = hesapFisForm.cariHesapId;
            hesapFis.tarih = System.DateTime.Now;
            hesapFis.bakiye = bakiye;

            _connection.HesapFisEkle(hesapFis);

            return Json(new { 
                status = "success",
                message = "Başarıyla oluşturuldu."
            });
        }

        public IActionResult HesapDokumu()
        {
            return View();
        }

        [HttpPost]
        public JsonResult HesapDokumu(int cariHesapId)
        {
            var hesapDokumu = _connection.HesapFisFiltrele(cariHesapId);
            if (hesapDokumu.Count > 0)
            {
                float? toplam = 0;
                for (int i = 0; i < hesapDokumu.Count; i++)
                {
                    toplam += hesapDokumu[i].bakiye;
                }
                return Json(new
                {
                    status = "success",
                    data = new
                    {
                        hesapDokumu = hesapDokumu,
                        toplam = toplam
                    }
                });
            }
            return Json(new
            {
                status = "error",
                message = "Kayıt bulunmuyor."
            });
        }
    }
}
