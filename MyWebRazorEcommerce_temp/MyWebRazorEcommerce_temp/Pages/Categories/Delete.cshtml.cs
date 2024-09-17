using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWebRazorEcommerce_temp.Models;
using MyWebRazorEcommerce_temp.Data; 
namespace MyWebRazorEcommerce_temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }

        public IActionResult OnPost(int? id)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Remove(Category);
                _db.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
