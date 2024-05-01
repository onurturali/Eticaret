using Eticaret.Model;
using Eticaret.Panel.Managers;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Panel.Controllers
{
    [Route("satis")]
    public class SatisController : Controller
    {
        [Route("")]
        public async Task<ViewResult> Index(string faturaNo, DateTime baslangicTarihi, DateTime bitisTarihi, string tutar)
        {
            List<Satis> satislar;

            if (faturaNo == null && baslangicTarihi.Year == 1 && bitisTarihi.Year == 1 && tutar == null)
            {
                satislar = await SatisManager.TumunuGetir();
            }
            else
            {
                satislar = await SatisManager.Filtrele(faturaNo, baslangicTarihi, bitisTarihi, tutar);
            }

            return View(satislar);
        }
    }
}
