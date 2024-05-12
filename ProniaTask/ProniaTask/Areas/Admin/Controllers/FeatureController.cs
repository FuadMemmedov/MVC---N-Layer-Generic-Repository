using Microsoft.AspNetCore.Mvc;
using ProniaTask.Business.Enums;
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
        public async Task<IActionResult> Create(Feature feature)
        {

            if (!ModelState.IsValid)
                return View();
            await _featureService.AddFeature(feature);
            return RedirectToAction("index");

        }

        public IActionResult Delete(int id)
        {
            var existFeature = _featureService.GetFeature(x => x.Id == id);

            if (existFeature == null) return NotFound();
            return View(existFeature);
        }
       
        [HttpPost]
        public IActionResult DeletePost(int id)
        {

            try
            {
				_featureService.DeleteFeature(id);
			}
            catch (EntityNotFoundException ex)
            {

                return NotFound();
            }

            return RedirectToAction("index");
        }





        public IActionResult Update(int id)
        {
            var existFeature = _featureService.GetFeature(x => x.Id == id);

            if (existFeature == null) return NotFound();

            return View(existFeature);
        }

        [HttpPost]
        public IActionResult Update(Feature newFeature)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
				_featureService.UpdateFeature(newFeature.Id, newFeature);
			}
            catch (EntityNotFoundException ex)
            {

                return NotFound();
            }
           
            return RedirectToAction("index");
        }
    }
}
