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

        public Category category = new Category();

        public void OnGet(int id)
        {
            category = _categoryService.GetById(id);
        }

        public IActionResult OnPost()
        {
            Category category = new Category();
            category.Id = Convert.ToInt32(Request.Form["id"]);
            category.Name = Convert.ToString(Request.Form["name"]);
            _categoryService.Update(category);
            return Redirect("/Categories/GetAll");
        }
    }
}
