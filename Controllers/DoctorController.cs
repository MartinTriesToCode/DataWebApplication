using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FeverCheck()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FeverCheck(double temp, string scale)
        {
            ModelState.Clear();
            ViewBag.message = DoctorModel.CheckTemp(temp, scale);


            return View();
        }
    }
}
