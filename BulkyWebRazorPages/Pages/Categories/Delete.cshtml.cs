using BulkyWebRazorPages.Data;
using BulkyWebRazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazorPages.Pages.Categories;

public class Delete : PageModel
{
    private ApplicationDbContext _db;
    [BindProperty]
    public NewCategory Category { get; set; }

    public Delete(ApplicationDbContext context)
    {
        _db = context;
    }
    public void OnGet(int? id)
    {
        if (id != null && id != 0)
        {
            Category = _db.NewCategories.Find(id);
        }
    }

    public IActionResult OnPost()
    {
        NewCategory? obj = _db.NewCategories.Find(Category.Id);
        if (obj == null)
        {
           return NotFound();
        }
        _db.NewCategories.Remove(obj);
        _db.SaveChanges();
        TempData["Success"] = "Category deleted";
        return RedirectToPage("/Categories/Index");
    }
    
}