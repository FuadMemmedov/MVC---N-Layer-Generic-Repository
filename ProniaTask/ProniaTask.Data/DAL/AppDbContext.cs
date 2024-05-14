using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ProniaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProniaTask.Data.DAL;

public class AppDbContext:IdentityDbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<AppUser> Users { get; set; }
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
}
