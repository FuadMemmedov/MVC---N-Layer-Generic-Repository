using Microsoft.AspNetCore.Mvc;
using ProniaTask.Business.Enums;
using ProniaTask.Business.Exceptions;
using ProniaTask.Business.Services.Abstracts;
using ProniaTask.Business.Services.Concretes;
using ProniaTask.Core.Models;

namespace ProniaTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
		private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public IActionResult Index()
        {
            var sliders = _sliderService.GetAllSliders();
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
				await _sliderService.AddSlider(slider);
			}
            catch (ImageContentTypeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
               
            }
            catch (ImageSizeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }


           
            return RedirectToAction("index");

        }

        public IActionResult Update(int id)
        {
            var oldSlider = _sliderService.GetSlider(x => x.Id == id);
            if (oldSlider == null) return NotFound();
            return View(oldSlider);
        }

        [HttpPost]
        public IActionResult Update(Slider newSlider)
        {
			if (!ModelState.IsValid)
				return View();
			try
			{
				_sliderService.UpdateSlider(newSlider.Id, newSlider);
			}
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (ImageContentTypeException ex)
			{
				ModelState.AddModelError("ImageFile", ex.Message);
				return View();

			}
			catch (ImageSizeException ex)
			{
				ModelState.AddModelError("ImageFile", ex.Message);
				return View();
			}
		
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            var existSlider = _sliderService.GetSlider(x => x.Id == id);
            if(existSlider == null) return NotFound();
            return View(existSlider);
            
        }
        [HttpPost]
        public IActionResult DeleteSlider(int id)
        {
            try
            {
                _sliderService.DeleteSlider(id);

            }
            catch (EntityNotFoundException ex)
            {

                return NotFound();
            }
            return RedirectToAction("index");
        }
    }
}
