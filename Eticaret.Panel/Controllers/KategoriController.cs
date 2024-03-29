using Eticaret.Model;
using Eticaret.Panel.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Panel.Controllers
{
    [Route("kategori")]
    public class KategoriController : Controller
    {
        private readonly IKategoriService _kategoriService;

        public KategoriController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }

        [HttpGet, Route("")] // localhost/kategori
        public async Task<ViewResult> Index()
        {
            List<Kategori> kategoriler = await _kategoriService.GetAllAsync();
            ViewBag.CSHARPDERSI = "Onur";
            return View(kategoriler);
        }

        [HttpGet, Route("yeni")] // localhost/kategori/yeni
        public ViewResult Yeni()
        {
            return View();
        }

        [HttpGet, Route("duzenle/{id}")] // localhost/kategori/duzenle/KFGD23G-DFG32F-5YTH
        public async Task<ViewResult> Duzenle(Guid id)
        {
            Kategori kategori = await _kategoriService.GetAsync(id);
            return View(kategori);
        }

        [HttpPost, Route("olustur")]
        public async Task<ActionResult> Olustur(Kategori model)
        {
            bool sonuc = await _kategoriService.InsertAsync(model);
            return RedirectToAction("Index", "Kategori");
        }

        [HttpPost, Route("guncelle")]
        public async Task<ActionResult> Guncelle(Kategori model)
        {
            bool sonuc = await _kategoriService.UpdateAsync(model);
            return RedirectToAction("Index", "Kategori");
        }

        [HttpGet, Route("sil/{id}")]
        public async Task<ActionResult> Sil(Guid id)
        {
            bool sonuc = await _kategoriService.DeleteAsync(id);
            return RedirectToAction("Index", "Kategori");
        }

        [HttpGet, Route("aktiflestir/{id}")]
        public async Task<ActionResult> Aktiflestir(Guid id)
        {
            bool sonuc = await _kategoriService.AktiflestirAsync(id);
            return RedirectToAction("Index", "Kategori");
        }

        [HttpGet, Route("pasiflestir/{id}")]
        public async Task<ActionResult> Pasiflestir(Guid id)
        {
            bool sonuc = await _kategoriService.PasiflestirAsync(id);
            return RedirectToAction("Index", "Kategori");
        }
    }
}
