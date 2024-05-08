using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ProniaTask.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }
        

    }
}
