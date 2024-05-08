﻿using ProniaTask.Core.Models;
using ProniaTask.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaTask.Data.RepositoryConcretes;

public class ProductRepository:GenericRepository<Product>
{
    public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        
    }
}
