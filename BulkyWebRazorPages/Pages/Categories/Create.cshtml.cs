using BulkyWebRazorPages.Data;
using BulkyWebRazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazorPages.Pages.Categories;

public class Create : PageModel

{
    private readonly ApplicationDbContext _db;
    [BindProperty]
    public NewCategory Category { get; set; }

    public Create(ApplicationDbContext db)
    {
        _db = db;
    }


    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        _db.NewCategories.Add(Category);
        _db.SaveChanges();
        TempData["Success"] = "Category created successfully";
        return RedirectToPage("/Categories/Index");
    }
}