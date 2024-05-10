using Microsoft.AspNetCore.Mvc;
using ProniaTask.Business.Services.Abstracts;
using ProniaTask.Core.Models;

namespace ProniaTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }
        public IActionResult Index()
        {
            var categories =_categoryService.GetAllCategorys();
            return View(categories);
        }
        

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {

            

            await _categoryService.AddCategory(category);
            return RedirectToAction("index");

        }


        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            _categoryService.DeleteCategory(id);

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            var existCategory = _categoryService.GetCategory(x => x.Id == id);

            if (existCategory == null)
            {
                return NotFound();
            }

            return View(existCategory);
        }




        public IActionResult Update(int id)
        {
            var existCategory = _categoryService.GetCategory(x => x.Id == id);

            if (existCategory == null) throw new NullReferenceException();

            return View(existCategory);
        }

        [HttpPost]
        public IActionResult Update(Category newCategory)
        {
            _categoryService.UpdateCategory(newCategory.Id, newCategory);
            return RedirectToAction("index");
        }
    }
}
