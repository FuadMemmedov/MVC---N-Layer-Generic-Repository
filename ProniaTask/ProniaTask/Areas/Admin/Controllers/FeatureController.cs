using Microsoft.AspNetCore.Mvc;
using ProniaTask.Business.Services.Abstracts;
using ProniaTask.Core.Models;

namespace ProniaTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {

        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;

        }
        public IActionResult Index()
        {
            var features = _featureService.GetAllFeatures();
            return View(features);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Feature feature)
        {
            _featureService.AddFeature(feature);
            return RedirectToAction("index");

        }

        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
