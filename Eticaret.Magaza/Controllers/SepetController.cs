﻿using Eticaret.Magaza.Services;
using Eticaret.Model;
using Eticaret.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Magaza.Controllers
{
    [Route("sepet")]
    public class SepetController : Controller
    {
        private readonly ISatisService _satisService;
        private readonly ISatisDetayService _satisDetayService;

        public SepetController(ISatisService satisService, ISatisDetayService satisDetayService)
        {
            _satisService = satisService;
            _satisDetayService = satisDetayService;
        }

        [HttpPost, Route("sepet-onay")]
        public async Task<JsonResult> SepetOnay(List<SepetUrun> urunler)
        {
            Satis satis = new()
            {
                FaturaNo = await _satisService.GetLastFaturaNoAsync(),
                Tarih = DateTime.Now,
            };

            Guid yeniSatisId = await _satisService.CreateAsync(satis);

            List<SatisDetay> satisDetay = urunler.Select(m => new SatisDetay()
            {
                Adet = m.Adet,
                UrunId = m.Id,
                Fiyat = m.Fiyat,
                SatisId = yeniSatisId,
            }).ToList();

            await _satisDetayService.CreateAsync(satisDetay);

            string faturaNo = await _satisService.GetFaturaNoAsync(yeniSatisId);

            return Json(faturaNo);
        }

        [Route("")]
        public ViewResult Index()
        {
            return View();
        }
    }
}
