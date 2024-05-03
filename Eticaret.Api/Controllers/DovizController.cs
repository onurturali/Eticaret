using Eticaret.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DovizController : ControllerBase
    {
        private readonly List<Doviz> dovizler = new()
        {
            new() { Tarih = DateTime.Now, Ad = "USD", Kur = 32.5 },
            new() { Tarih = DateTime.Now, Ad = "EUR", Kur = 35.7 },
            new() { Tarih = DateTime.Now, Ad = "GBP", Kur = 40.3 },
            new() { Tarih = DateTime.Now, Ad = "RUB", Kur = .35 },
            new() { Tarih = DateTime.Now, Ad = "CAD", Kur = 23.62 },
        };

        [HttpGet, Route("[action]")]
        public ActionResult Get([FromQuery(Name = "doviz")] string? dovizAdi)
        {

            if (string.IsNullOrEmpty(dovizAdi))
            {
                return Ok(dovizler);
            }
            else
            {
                Doviz? doviz = dovizler.Where(m => m.Ad == dovizAdi.ToUpper()).FirstOrDefault();

                if (doviz != null) return Ok(doviz);
                else return NotFound(new { mesaj = $"'{dovizAdi.ToUpper()}' bulunamadı." });
            }
        }
    }
}