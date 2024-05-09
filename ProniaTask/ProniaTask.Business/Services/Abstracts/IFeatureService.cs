using ProniaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaTask.Business.Services.Abstracts;

public interface IFeatureService
{
    Task AddFeature(Feature features);
    void DeleteFeature(int id);
    void UpdateFeature(int id, Feature newFeatures);
    Feature GetFeature(Func<Feature, bool>? func = null);
    List<Feature> GetAllFeatures(Func<Feature, bool>? func = null);
}
