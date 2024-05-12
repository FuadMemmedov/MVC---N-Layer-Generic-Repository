using Microsoft.AspNetCore.Mvc;
using ProniaTask.Business.Enums;
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
            if (!ModelState.IsValid)
                return View();

            try
            {
				await _categoryService.AddCategory(category);
			}
            catch (DuplicateCategoryException ex)
            {

                ModelState.AddModelError("Name", ex.Message);
                return View();
            }
            return RedirectToAction("index");

        }


        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            try
            {
				_categoryService.DeleteCategory(id);
			}
            catch (EntityNotFoundException ex)
            {
                return NotFound();
                
            }
                

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

            if (existCategory == null) return NotFound();

            return View(existCategory);
        }

        [HttpPost]
        public IActionResult Update(Category newCategory)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
				_categoryService.UpdateCategory(newCategory.Id, newCategory);
			}
            catch (EntityNotFoundException ex)
            {

                return NotFound();
            }
            catch (DuplicateCategoryException ex)
            {
                ModelState.AddModelError("Name",ex.Message);
                return View();
            }
			
            return RedirectToAction("index");
        }
    }
}
