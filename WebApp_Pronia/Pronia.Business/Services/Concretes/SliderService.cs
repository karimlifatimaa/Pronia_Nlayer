using Pronia.Business.Services.Abstracts;
using Pronia.Core.Models;
using Pronia.Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Business.Services.Concretes
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;

        public SliderService(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

        public void AddSlider(Slider slider)
        {
            if(slider == null) throw new NullReferenceException("Slider null ola bilmez");
            _sliderRepository.Add(slider);
            _sliderRepository.Commit();
        }

        public List<Slider> GetAllSliders(Func<Slider, bool>? func = null)
        {
            return _sliderRepository.GetAll(func);
        }

        public Slider GetSlider(Func<Slider, bool>? func = null)
        {
            return _sliderRepository.Get(func);
        }

        public void DeleteSlider(int id)
        {
            var slider=_sliderRepository.Get(x=>x.Id==id);
            if (slider == null) throw new NullReferenceException("Bele slider yoxdur");
            _sliderRepository.Delete(slider);
            _sliderRepository.Commit();
        }

        public void UpdateSlider(int id, Slider newSlider)
        {
            var slider = _sliderRepository.Get(x => x.Id == id);
            if (slider == null) throw new NullReferenceException("Bele slider yoxdur");
            slider.Title = newSlider.Title;
            slider.SubTitle = newSlider.SubTitle;
            slider.ImgUrl = newSlider.ImgUrl;
            slider.Description = newSlider.Description;
            _sliderRepository.Commit();
        }
    }
}
