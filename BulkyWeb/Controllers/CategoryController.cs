using BulkyWeb.Data;
using Microsoft.AspNetCore.Mvc;
using BulkyWeb.Models;

namespace BulkyWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _context;

    public CategoryController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        List<Category> objCategories = _context.Categories.ToList();
        return View(objCategories);
    }

    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Category newCategory)
    {
        if (newCategory.Name == newCategory.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Name", "Name and display order must be unique");
        }
        if (ModelState.IsValid)
        {
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            TempData["Success"] = "Category created successfully";
            return RedirectToAction("Index", "Category");
        }

        return View();

    }
    
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Category? categoryFound = _context.Categories.Find(id);
        
        if (categoryFound == null)
        {
            return NotFound();
        }
        return View(categoryFound);
    }
    
    [HttpPost]
    public IActionResult Edit(Category categoryToEdit)
    {
        if (ModelState.IsValid)
        {
            _context.Categories.Update(categoryToEdit);
            _context.SaveChanges();
            TempData["Success"] = "Category updated successfully";
            return RedirectToAction("Index", "Category");
        }

        return View();

    }
    
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Category? categoryFound = _context.Categories.Find(id);
        
        if (categoryFound == null)
        {
            return NotFound();
        }
        return View(categoryFound);
    }
    
    [HttpPost, ActionName("Delete")]
    public IActionResult Delete(int id)
    {
        Category categoryToDelete = _context.Categories.Find(id);
        if (categoryToDelete == null)
        {
            return NotFound();
        }
        _context.Categories.Remove(categoryToDelete);
        _context.SaveChanges();
        TempData["Success"] = "Category deleted successfully";
        return RedirectToAction("Index", "Category");
        
    }
}