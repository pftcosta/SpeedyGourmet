using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly IService<Category, int> _serviceCategory;

        public DeleteModel(IService<Category, int> serviceCategory)
        {
            _serviceCategory = serviceCategory;
        }

        public IActionResult OnGet(int id)
        {
            _serviceCategory.Delete(id);
            return Redirect("/Categories/GetAll");
        }
    }
}
