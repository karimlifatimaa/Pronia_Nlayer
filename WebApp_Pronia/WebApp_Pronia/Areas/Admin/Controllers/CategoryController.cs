using Microsoft.AspNetCore.Mvc;
using Pronia.Business.Exceptions;
using Pronia.Business.Services.Abstracts;
using Pronia.Core.Models;

namespace WebApp_Pronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories=_categoryService.GetAllCategories();
            return View(categories);
        }
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _categoryService.AddCategory(category);
            }
            catch (DuplicateCategoryException ex)
            {
                ModelState.AddModelError(ex.PropertyName,ex.Message);          
                return View();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var category=_categoryService.GetCategory(x => x.Id == id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _categoryService.Update(category.Id, category);
            }
            catch (DuplicateCategoryException ex)
            {

                ModelState.AddModelError(ex.PropertyName,ex.Message);
                return View();
            }
            
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) 
        {
            _categoryService.DeleteCategory(id);           
            return RedirectToAction("Index");
        }
    }
}
