using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Categories
{
    public class GetById : PageModel
    {
        private readonly IService<Category, int> _serviceCategory;

        public GetById (IService<Category, int> serviceCategory)
        {
            _serviceCategory = serviceCategory;
        }

        public Category Category { get; set; }
        public User User { get; set; }

        public void OnGet(int categoryId)
        {
            GetUser();
            Category = _serviceCategory.GetById(categoryId);
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
