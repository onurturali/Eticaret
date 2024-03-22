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
            return View(kategoriler);
        }

        [HttpGet, Route("yeni")] // localhost/kategori/yeni
        public ViewResult Yeni()
        {
            return View();
        }

        [HttpPost, Route("olustur")]
        public async Task<ActionResult> Olustur(Kategori model)
        {
            bool sonuc = await _kategoriService.InsertAsync(model);
            return RedirectToAction("Index", "Kategori");
        }
    }
}
