using ProniaTask.Business.Enums;
using ProniaTask.Business.Services.Abstracts;
using ProniaTask.Core.Models;
using ProniaTask.Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaTask.Business.Services.Concretes;

public class CategoryService:ICategoryService
{
   private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task AddCategory(Category Category)
    {
        if (!_categoryRepository.GetAll().Any(x => x.Name == Category.Name ))
        {

            await _categoryRepository.AddAsync(Category);
            await _categoryRepository.CommitAsync();
        }
        else
        {
            throw new DuplicateCategoryException("Eyni adli category ola bilmez");
        }

    }

    public void DeleteCategory(int id)
    {
        var existCategory = _categoryRepository.Get(x => x.Id == id);
        if (existCategory == null) throw new EntityNotFoundException("Category tapilmadi");

        _categoryRepository.Delete(existCategory);
        _categoryRepository.Commit();

    }

    public List<Category> GetAllCategorys(Func<Category, bool>? func = null)
    {
        return _categoryRepository.GetAll(func);
    }

    public Category GetCategory(Func<Category, bool>? func = null)
    {
        return _categoryRepository.Get(func);
    }

    public void UpdateCategory(int id, Category newCategory)
    {
        Category oldCategory = _categoryRepository.Get(x => x.Id == id);
        if (oldCategory == null ) throw new EntityNotFoundException("Category tapilmadi");
        if (!_categoryRepository.GetAll().Any(x => x.Name == newCategory.Name && x.Id != oldCategory.Id))
        {
            oldCategory.Name = newCategory.Name;
			_categoryRepository.Commit();

		}
        else
        {
            throw new DuplicateCategoryException("Eyni adli categorry ola bilmez");
        }
      
    }
}
