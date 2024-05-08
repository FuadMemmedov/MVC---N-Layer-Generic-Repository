using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaTask.Core.Models;

public class Category:BaseEntity
{
    public string Name { get; set; }
    List<Product> Products { get; set; }
}
