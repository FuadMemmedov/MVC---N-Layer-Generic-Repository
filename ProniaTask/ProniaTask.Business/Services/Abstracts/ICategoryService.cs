﻿using ProniaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaTask.Business.Services.Abstracts;

public interface ICategoryService
{
    Task AddCategory(Category category);
    void DeleteCategory(int id);
    void UpdateCategory(int id, Category newCategory);
    Category GetCategory(Func<Category, bool>? func = null);
    List<Category> GetAllCategorys(Func<Category, bool>? func = null);
}
