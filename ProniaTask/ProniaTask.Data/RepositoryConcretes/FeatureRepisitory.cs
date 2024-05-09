using ProniaTask.Core.Models;
using ProniaTask.Core.RepositoryAbstracts;
using ProniaTask.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaTask.Data.RepositoryConcretes;

public class FeatureRepisitory : GenericRepository<Feature>, IFeatureRepository
{
    public FeatureRepisitory(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
