using Eticaret.Magaza.Services;
using Eticaret.Model;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Magaza.Controllers
{
    [Route("fatura")]
    public class FaturaController : Controller
    {
        ISatisService _satisService;
        ISatisDetayService _satisDetayService;

        public FaturaController(ISatisService satisService, ISatisDetayService satisDetayService)
        {
            _satisService = satisService;
            _satisDetayService = satisDetayService;

        }

        [Route("{faturaNo}")]
        public async Task<ViewResult> Index(string faturaNo)
        {
            Satis satis = await _satisService.GetByFaturaNoAsync(faturaNo);
            List<SatisDetay> satisDetay = await _satisDetayService.GetBySatis(satis.Id);

            ViewBag.Satis = satis;
            ViewBag.SatisDetay = satisDetay;

            return View();
        }
    }
}
