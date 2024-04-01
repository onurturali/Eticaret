using Eticaret.Model;
using Eticaret.Panel.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Eticaret.Panel.Controllers
{
    [AllowAnonymous, Route("oturum")]
    public class OturumController : Controller
    {
        private readonly IKullaniciService _kullaniciService;

        public OturumController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        [HttpGet, Route("giris")]
        public ViewResult Giris()
        {
            return View();
        }

        [HttpPost, Route("giris")]
        public async Task<ActionResult> GirisYap(Kullanici model)
        {
            Kullanici? kullanici = await _kullaniciService.GirisAsync(model.KullaniciAdi, model.Parola);

            if (kullanici != null)
            {
                List<Claim> claims = new()
                {
                    new("KullaniciAdi", kullanici.KullaniciAdi),
                };

                AuthenticationProperties authenticationProperties = new();
                ClaimsIdentity identity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity), authenticationProperties);
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Giris", "Oturum");
        }

        [HttpGet, Route("cikis")]
        public async Task<ActionResult> CikisYap()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Giris", "Oturum");
        }
    }
}
