using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Categories
{
    public class Delete : PageModel
    {
        private readonly IService<Category, int> _serviceCategory;

        public Delete (IService<Category, int> serviceCategory)
        {
            _serviceCategory = serviceCategory;
        }
        public User User { get; set; }

        public IActionResult OnGet(int categoryId)
        {
            GetUser();
            _serviceCategory.Delete(categoryId);
            return Redirect("/Categories/GetAll");
        }

        private void GetUser()
        {
            string user = HttpContext.Session.GetString("user");
            if (user != null)
            {
                User = JsonSerializer.Deserialize<User>(user);
            }
        }
    }
}
