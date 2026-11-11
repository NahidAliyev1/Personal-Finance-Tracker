using Microsoft.EntityFrameworkCore;
using Personal_Finance_Tracker.Contexts;
using Personal_Finance_Tracker.Exceptions;
using Personal_Finance_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker.Services;
public class CategoryService
{
  
    private readonly PersonalFinanceTrackerDbContext _context;
    private readonly DbSet<Category> _categoryDb;


    public CategoryService()
    {
      
        _context = new PersonalFinanceTrackerDbContext();
        _categoryDb = _context.Set<Category>();
    }

    public void Add(string name,Typee typee)
    {
        if (name is not null && typee>0)
        {
            Category category = new Category(name,typee);
            
            _categoryDb.Add(category);
            _context.SaveChanges();
        }
        else
        {
            throw new CustomException("Name ve ya type de yanlisklik var");
        }
    }
    public List<Category> GetAllCategories()
    {
        return _context.Categories.ToList();
    }
    public void DeleteCategory(int id)
    {
        Category? category = _categoryDb.Find(id);
        if (category is not null)
        {
            _categoryDb.Remove(category);
            _context.SaveChanges();
        }
        else
        {
            throw new CustomException($"{id} id li bir Category tapilmadi");
            
        }
    }
}
