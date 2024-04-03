using Eticaret.Magaza.Services;
using Eticaret.Model;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Magaza.Controllers
{
    [Route("kategori")]
    public class KategoriController : Controller
    {
        private readonly IKategoriService _kategoriService;
        private readonly IUrunService _urunService;

        public KategoriController(IKategoriService kategoriService, IUrunService urunService)
        {
            _kategoriService = kategoriService;
            _urunService = urunService;
        }

        [HttpGet, Route("{url}")]
        public async Task<ViewResult> Index(string url)
        {
            Kategori? kategori = await _kategoriService.GetAsync(url);
            List<Urun> urunler = new();

            if (kategori != null)
                urunler = await _urunService.GetAllByKategori(kategori.Id);

            ViewBag.Kategori = kategori;
            ViewBag.Urunler = urunler;

            return View();
        }
    }
}
