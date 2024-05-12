using Pronia.Business.Exceptions;
using Pronia.Business.Services.Abstracts;
using Pronia.Core.Models;
using Pronia.Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Business.Services.Concretes;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public void AddCategory(Category category)
    {
        if(category==null) throw new NullReferenceException("Category null ola bilmez");

        if (!_categoryRepository.GetAll().Any(x => x.Name == category.Name))
        {
            _categoryRepository.Add(category);
            _categoryRepository.Commit();
        }
        else
        {
            throw new DuplicateCategoryException("Name","Eyni adda kategory ola bilmez");
        }
        
        
    }

    public void DeleteCategory(int id)
    {
        var category = _categoryRepository.Get(x=>x.Id==id);
        if (category == null) throw new NullReferenceException("Bele bir kategoriya yoxdur");
        _categoryRepository.Delete(category);
        _categoryRepository.Commit();
    }

    public List<Category> GetAllCategories(Func<Category, bool>? func = null)
    {
        return _categoryRepository.GetAll(func);
    }

    public Category GetCategory(Func<Category, bool>? func = null)
    {
        return _categoryRepository.Get(func);
    }

    public void Update(int id, Category newCategory)
    {
        var category = _categoryRepository.Get(x => x.Id == id);
        if (category == null) throw new NullReferenceException("Bele bir kategoriya yoxdur");
        if(!_categoryRepository.GetAll().Any(x=>x.Name==newCategory.Name)) 
        {
            category.Name = newCategory.Name;
            _categoryRepository.Commit();
        }
        else
        {
            throw new DuplicateCategoryException("Name","Eyni adda kategory ola bilmez");
        }

    }
}
