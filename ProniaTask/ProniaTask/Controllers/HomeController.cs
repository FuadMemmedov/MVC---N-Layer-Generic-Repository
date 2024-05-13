using Microsoft.AspNetCore.Mvc;
using ProniaTask.Business.Services.Abstracts;
using ProniaTask.Core.Models;
using ProniaTask.ViewModels;
using System.Diagnostics;

namespace ProniaTask.Controllers
{
    public class HomeController : Controller
    {
		private readonly IFeatureService _featureService;
        private readonly ISliderService _sliderService;
        public HomeController(IFeatureService featureService,ISliderService sliderService)
        {
            _featureService = featureService;
            _sliderService = sliderService;
        }
        

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Features = _featureService.GetAllFeatures(),
                Sliders = _sliderService.GetAllSliders()
            };

            return View(homeVM);
        }

        public IActionResult Index2()
        {
            return View();
        }




       
        

    }
}
