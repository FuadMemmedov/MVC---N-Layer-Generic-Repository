using ProniaTask.Business.Services.Abstracts;
using ProniaTask.Core.Models;
using ProniaTask.Core.RepositoryAbstracts;
using ProniaTask.Data.RepositoryConcretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaTask.Business.Services.Concretes;

public class FeatureService : IFeatureService
{
    IFeatureRepository _featuresRepository;

    public FeatureService(IFeatureRepository featuresRepository)
    {
        _featuresRepository = featuresRepository;
    }
    public async Task AddFeature(Feature features)
    {
        await _featuresRepository.AddAsync(features);
        await _featuresRepository.CommitAsync();
    }

    public void DeleteFeature(int id)
    {
        var existFeature = _featuresRepository.Get(x => x.Id == id);
        if (existFeature == null) throw new NullReferenceException("Bele feature yoxdur");

        _featuresRepository.Delete(existFeature);
        _featuresRepository.Commit();

    }

    public List<Feature> GetAllFeatures(Func<Feature, bool>? func = null)
    {
        return _featuresRepository.GetAll(func);
    }

    public Feature GetFeature(Func<Feature, bool>? func = null)
    {
        return _featuresRepository.Get(func);
    }

    public void UpdateFeature(int id, Feature newFeature)
    {
        Feature oldFeature = _featuresRepository.Get(x => x.Id == id);
        if (oldFeature == null) throw new NullReferenceException("Bele feature yoxdur");


        oldFeature.Icon = newFeature.Icon;
        oldFeature.Title = newFeature.Title;
        oldFeature.Description = newFeature.Description;


        _featuresRepository.Commit();
    }
}
