using Microsoft.AspNetCore.Mvc;

namespace task2.Controllers
{
    public class RemoteController : Controller
    {
        public IActionResult adress(string address)
        {
            if (address == "Cairo" || address == "Alex" || address == "Giza")
                return Json(true);
            else
                return Json(false);
        }
    }
}
