using Eticaret.Model.ViewModels;
using Eticaret.Panel.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Panel.Controllers
{
    [Authorize, Route("")]
    public class HomeController : Controller
    {
        [Route("")]
        public async Task<ViewResult> Index()
        {
            Home? ozet = await HomeManager.OzetToplam();
            ViewBag.Ozet = ozet;
            return View();
        }

        [Route("profil")]
        public ViewResult Profil()
        {
            return View();
        }
    }
}