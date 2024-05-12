using Microsoft.AspNetCore.Mvc;
using ProniaTask.Business.Services.Abstracts;
using ProniaTask.Core.Models;

namespace ProniaTask.Controllers
{
    public class ShopController : Controller
    {
		private readonly ICategoryService _categoryService;

        public ShopController(ICategoryService categoryService)
        {
            _categoryService = categoryService; 
        }
        public IActionResult Index()
        {
            List<Category> categories = _categoryService.GetAllCategorys();

            return View(categories);
        }

        public IActionResult Detail()
        {
            return View();
        }

    }
}
