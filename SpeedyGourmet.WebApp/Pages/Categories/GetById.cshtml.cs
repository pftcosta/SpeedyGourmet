using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Categories
{
    public class GetByIdModel : PageModel
    {
        private readonly IService<Category, int> _serviceCategory;

        public GetByIdModel(IService<Category, int> serviceCategory)
        {
            _serviceCategory = serviceCategory;
        }

        public Category category = new Category();

        public void OnGet(int id)
        {
            category = _serviceCategory.GetById(id);
        }
    }
}
