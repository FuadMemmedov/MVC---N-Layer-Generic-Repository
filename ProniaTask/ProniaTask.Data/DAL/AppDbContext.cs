using Microsoft.EntityFrameworkCore;
using ProniaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaTask.Data.DAL;

public class AppDbContext:DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
}
