using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Categories
{
    public class Update : PageModel
    {
        private readonly IService<Category, int> _categoryService;

        public Update (IService<Category, int> categoryService)
        {
            _categoryService = categoryService;
        }

        public Category Category { get; private set; }

        public void OnGet(int categoryId)
        {
            Category = _categoryService.GetById(categoryId);
        }

        public IActionResult OnPost()
        {
            Category = new Category()
            {
                Id = Convert.ToInt32(Request.Form["id"]),
                Name = Convert.ToString(Request.Form["name"])
            };
            _categoryService.Update(Category);
            return Redirect("/Categories/GetAll");
        }
    }
}
