using BulkyWebRazorPages.Data;
using BulkyWebRazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazorPages.Pages.Categories;

public class Edit : PageModel
{
    private readonly ApplicationDbContext _db;
    [BindProperty]
    public NewCategory Category { get; set; }

    public Edit(ApplicationDbContext db)
    {
        _db = db;
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
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _db.NewCategories.Update(Category);
        _db.SaveChanges();
        TempData["Success"] = "Category updated";
        return RedirectToPage("/Categories/Index");
    }
}