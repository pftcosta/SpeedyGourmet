using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Categories
{
    public class GetAllModel : PageModel
    {
        private readonly IService<Category, int> _categoryService;

        public GetAllModel(IService<Category, int> categoryService)
        {
            _categoryService = categoryService;
        }

        public List<Category> categories { get; set; }

        public void OnGet()
        {
            categories = _categoryService.GetAll();
        }

        public void OnPost()
        {
            Category category = new Category();
            category.Name = Convert.ToString(Request.Form["name"]);
            _categoryService.Create(category);
            OnGet();
        }
    }
}
