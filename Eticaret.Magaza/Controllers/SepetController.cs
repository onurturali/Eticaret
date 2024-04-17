using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Magaza.Controllers
{
    [Route("sepet")]
    public class SepetController : Controller
    {
        [Route("")]
        public ViewResult Index()
        {
            return View();
        }
    }
}
