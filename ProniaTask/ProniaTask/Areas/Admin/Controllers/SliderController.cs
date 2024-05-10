using Microsoft.AspNetCore.Mvc;
using ProniaTask.Business.Services.Abstracts;
using ProniaTask.Business.Services.Concretes;
using ProniaTask.Core.Models;

namespace ProniaTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public IActionResult Index()
        {
            var slider = _sliderService.GetAllSliders();
            return View(slider);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {

            await _sliderService.AddSlider(slider);
            return RedirectToAction("index");

        }
    }
}
