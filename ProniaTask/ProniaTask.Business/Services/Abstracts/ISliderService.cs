using ProniaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaTask.Business.Services.Abstracts;

public interface ISliderService
{
    Task AddSlider(Slider slider);
    void DeleteSlider(int id);
    void UpdateSlider(int id, Slider newSliders);
    Slider GetSlider(Func<Slider, bool>? func = null);
    List<Slider> GetAllSliders(Func<Slider, bool>? func = null);
}
