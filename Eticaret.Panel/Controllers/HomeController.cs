using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Panel.Controllers
{
    [Authorize, Route("")]
    public class HomeController : Controller
    {
        [Route("")]
        public ViewResult Index()
        {
            return View();
        }

        [Route("profil")]
        public ViewResult Profil()
        {
            return View();
        }
    }
}