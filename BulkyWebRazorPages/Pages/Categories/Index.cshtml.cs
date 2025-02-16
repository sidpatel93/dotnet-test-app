using BulkyWebRazorPages.Data;
using BulkyWebRazorPages.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazorPages.Pages.Categories;

public class Index : PageModel
{
    private readonly ApplicationDbContext _db;
    public List<NewCategory> CategoryList { get; set; }

    public Index(ApplicationDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
       CategoryList =  _db.NewCategories.ToList();
    }
}