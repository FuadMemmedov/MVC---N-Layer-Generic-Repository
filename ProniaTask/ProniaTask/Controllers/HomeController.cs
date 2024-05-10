using Microsoft.AspNetCore.Mvc;
using ProniaTask.Business.Services.Abstracts;
using System.Diagnostics;

namespace ProniaTask.Controllers
{
    public class HomeController : Controller
    {
        IFeatureService _featureService;
        public HomeController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        public IActionResult Index()
        {
          var features =  _featureService.GetAllFeatures();
            return View(features);
        }

       
        

    }
}
