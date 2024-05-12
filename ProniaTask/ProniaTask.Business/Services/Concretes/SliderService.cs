using ProniaTask.Business.Enums;
using ProniaTask.Business.Exceptions;
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
        if (slider.ImageFile.ContentType != "image/png" && slider.ImageFile.ContentType != "image/jpeg")
            throw new ImageContentTypeException("Fayl formati duzgun deyil!");
        if (slider.ImageFile.Length > 2097152)
            throw new ImageSizeException("Sheklin olcusu max 2mb ola biler");

        var extension = Path.GetExtension(slider.ImageFile.FileName);
        var fileName = $"slider={Guid.NewGuid().ToString().ToLower()}{extension}";
         
        string path = "C:\\Users\\memme\\Desktop\\MVC---N-Layer-Generic-Repository\\ProniaTask\\ProniaTask\\wwwroot\\uploads\\sliders\\" + fileName ;

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
        if (existSlider == null) throw new EntityNotFoundException("Bele slider yoxdur!");
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

    public void UpdateSlider(int id, Slider newSlider)
    {
        var oldSlider = _sliderRepository.Get(x => x.Id == id);
        if (oldSlider == null) throw new EntityNotFoundException("Bele bir slider yoxdur!");

		if (newSlider.ImageFile.ContentType != "image/png" && newSlider.ImageFile.ContentType != "image/jpeg")
			throw new ImageContentTypeException("Fayl formati duzgun deyil!");
		if (newSlider.ImageFile.Length > 2097152)
			throw new ImageSizeException("Sheklin olcusu max 2mb ola biler");

		var extension = Path.GetExtension(newSlider.ImageFile.FileName);
		var fileName = $"slider={Guid.NewGuid().ToString().ToLower()}{extension}";

		string path = "C:\\Users\\memme\\Desktop\\MVC---N-Layer-Generic-Repository\\ProniaTask\\ProniaTask\\wwwroot\\uploads\\sliders\\" + fileName;

		; using (FileStream fileStream = new FileStream(path, FileMode.Create))
		{
			newSlider.ImageFile.CopyTo(fileStream);
		}

		oldSlider.ImageUrl = fileName;
        oldSlider.Title = newSlider.Title;
        oldSlider.Description = newSlider.Description;
        oldSlider.Offer = newSlider.Description;



		_sliderRepository.Commit();
       
    }
}
