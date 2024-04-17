using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Magaza.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        int sayi = 10;
        [HttpGet, Route("")]
        public ActionResult Index()
        {
            int sayi = 5;
            Console.WriteLine(this.sayi);
            return View();
        }
    }
}