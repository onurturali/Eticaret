using Eticaret.Model;
using Eticaret.Panel.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Panel.Controllers
{
    [Authorize, Route("urun")]
    public class UrunController : Controller
    {
        private readonly IUrunService _urunService;
        private readonly IKategoriService _kategoriService;

        public UrunController(IUrunService urunService, IKategoriService kategoriService)
        {
            _urunService = urunService;
            _kategoriService = kategoriService;
        }

        [Route("")]
        public async Task<ViewResult> Index()
        {
            List<Urun> urunler = await _urunService.GetAllAsync();
            return View(urunler);
        }

        [Route("yeni")]
        public async Task<ViewResult> Yeni()
        {
            List<Kategori> kategoriler = await _kategoriService.GetAllAsync();
            ViewBag.Kategoriler = kategoriler;
            return View();
        }

        [Route("duzenle/{id}")]
        public async Task<ViewResult> Duzenle(Guid id)
        {
            Urun urun = await _urunService.GetAsync(id);
            List<Kategori> kategoriler = await _kategoriService.GetAllAsync();
            ViewBag.Kategoriler = kategoriler;
            return View(urun);
        }

        [Route("olustur")]
        public async Task<ActionResult> Olustur(Urun model, IFormFile gorsel)
        {
            if (gorsel != null)
            {
                string dosyaAdi = gorsel.FileName;
                List<string> dosyaParcalari = dosyaAdi.Split('.').ToList();
                string dosyaUzantisi = dosyaParcalari.Last();
                string yeniDosyaAdi = Guid.NewGuid().ToString();
                // yeniDosyaAdi = $"{yeniDosyaAdi}.{dosyaUzantisi}"; alttaki ile aynı işi yapıyor
                yeniDosyaAdi += $".{dosyaUzantisi}";

                // IO = input - output, dosya yazma, okuma, silme her zaman stream'dir.
                using FileStream fs = new($"./wwwroot/img/{yeniDosyaAdi}", FileMode.Create);
                await gorsel.CopyToAsync(fs);
                model.GorselAd = yeniDosyaAdi;
            }

            bool sonuc = await _urunService.InsertAsync(model);
            return RedirectToAction("Index", "Urun");
        }

        [HttpPost, Route("guncelle")]
        public async Task<ActionResult> Guncelle(Urun model, IFormFile gorsel)
        {
            if (gorsel != null)
            {
                string dosyaAdi = gorsel.FileName;
                List<string> dosyaParcalari = dosyaAdi.Split('.').ToList();
                string dosyaUzantisi = dosyaParcalari.Last();
                string yeniDosyaAdi = Guid.NewGuid().ToString();
                // yeniDosyaAdi = $"{yeniDosyaAdi}.{dosyaUzantisi}"; alttaki ile aynı işi yapıyor
                yeniDosyaAdi += $".{dosyaUzantisi}";

                // IO = input - output, dosya yazma, okuma, silme her zaman stream'dir.
                using FileStream fs = new($"./wwwroot/img/{yeniDosyaAdi}", FileMode.Create);
                await gorsel.CopyToAsync(fs);
                model.GorselAd = yeniDosyaAdi;
            }

            bool sonuc = await _urunService.UpdateAsync(model);
            return RedirectToAction("Index", "Urun");
        }

        [HttpGet, Route("aktiflestir/{id}")]
        public async Task<ActionResult> Aktiflestir(Guid id)
        {
            bool sonuc = await _urunService.AktiflestirAsync(id);
            return RedirectToAction("Index", "Urun");
        }

        [HttpGet, Route("pasiflestir/{id}")]
        public async Task<ActionResult> Pasiflestir(Guid id)
        {
            bool sonuc = await _urunService.PasiflestirAsync(id);
            return RedirectToAction("Index", "Urun");
        }
    }
}
