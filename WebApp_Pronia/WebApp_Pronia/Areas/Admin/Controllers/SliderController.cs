using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.Business.Exceptions;
using Pronia.Business.Services.Abstracts;
using Pronia.Business.Services.Concretes;
using Pronia.Core.Models;

namespace WebApp_Pronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        IWebHostEnvironment _environment;
        public SliderController(ISliderService sliderService, IWebHostEnvironment environment)
        {
            _sliderService = sliderService;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var sliders=_sliderService.GetAllSliders();
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (!slider.ImageFile.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("PhotoFile", "Formati duzgun daxil edin");
                return View();
            }


            string filename = slider.ImageFile.FileName;
            string path = _environment.WebRootPath + @"\Upload\Slider\" + filename;
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                slider.ImageFile.CopyTo(stream);

            }


            slider.ImgUrl = filename;


            if (!ModelState.IsValid)
            {
                return View();
            }
            _sliderService.AddSlider(slider);
           
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _sliderService.DeleteSlider(id);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var slider=_sliderService.GetSlider(x=>x.Id==id);
            return View(slider);
         
        }
        [HttpPost]
        public IActionResult Update(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _sliderService.UpdateSlider(slider.Id, slider);
            }
            catch (DuplicateCategoryException ex)
            {

                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }

            return RedirectToAction("Index");
        }
    }
}
