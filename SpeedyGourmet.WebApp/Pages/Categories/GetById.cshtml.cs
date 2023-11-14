using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Categories
{
    public class GetById : PageModel
    {
        private readonly IService<Category, int> _serviceCategory;

        public GetById (IService<Category, int> serviceCategory)
        {
            _serviceCategory = serviceCategory;
        }

        public Category Category { get; private set; }

        public void OnGet(int categoryId)
        {
            Category = _serviceCategory.GetById(categoryId);
        }
    }
}
