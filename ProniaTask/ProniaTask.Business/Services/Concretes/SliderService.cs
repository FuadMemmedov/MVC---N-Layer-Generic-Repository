using ProniaTask.Business.Services.Abstracts;
using ProniaTask.Core.Models;
using ProniaTask.Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaTask.Business.Services.Concretes;

public class SliderService : ISliderService
{
    private readonly ISliderRepository _sliderRepository;

    public SliderService(ISliderRepository sliderRepository)
    {
        _sliderRepository = sliderRepository;
    }

    public async Task AddSlider(Slider slider)
    {

        var extension = Path.GetExtension(slider.ImageFile.FileName);
        var fileName = $"slider={Guid.NewGuid().ToString().ToLower()}{extension}";
         
        string path = "C:\\Users\\memme\\Desktop\\MVC---N-Layer-Generic-Repository-main\\ProniaTask\\ProniaTask\\wwwroot\\admin\\uploads\\sliders\\" + fileName ;

;       using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            slider.ImageFile.CopyTo(fileStream);
        }

       slider.ImageUrl = fileName ;

        await _sliderRepository.AddAsync(slider);
        await _sliderRepository.CommitAsync();
    }

    public void DeleteSlider(int id)
    {
        var existSlider = _sliderRepository.Get(x => x.Id == id);
       _sliderRepository.Delete(existSlider);
        _sliderRepository.Commit();
    }

    public List<Slider> GetAllSliders(Func<Slider, bool>? func = null)
    {
        return _sliderRepository.GetAll();
    }

    public Slider GetSlider(Func<Slider, bool>? func = null)
    {
        return _sliderRepository.Get(func);
    }

    public void UpdateSlider(int id, Slider newSliders)
    {
        var oldSlider = _sliderRepository.Get(x=>x.Id == id);

        oldSlider.Offer = newSliders.Offer;
        oldSlider.Title = newSliders.Title;
        oldSlider.Description = newSliders.Description;
        oldSlider.RedirectUrl = newSliders.RedirectUrl;
        

        _sliderRepository.Commit();
       
    }
}
