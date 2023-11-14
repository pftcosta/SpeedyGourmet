using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Categories
{
    public class GetAll : PageModel
    {
        private readonly IService<Category, int> _categoryService;

        public GetAll (IService<Category, int> categoryService)
        {
            _categoryService = categoryService;
        }

        public List<Category> Categories { get; private set; }

        public void OnGet()
        {
            Categories = _categoryService.GetAll();
        }

        public void OnPost()
        {
            string categoryName = Convert.ToString(Request.Form["name"]);
            _categoryService.Create(new Category { Name = categoryName });
            OnGet();
        }
    }
}
