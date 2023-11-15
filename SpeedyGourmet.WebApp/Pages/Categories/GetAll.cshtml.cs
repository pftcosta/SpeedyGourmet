using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

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

        public User User { get; set; }

        public void OnGet()
        {
            GetUser();
            Categories = _categoryService.GetAll();
        }

        public void OnPost()
        {
            string categoryName = Convert.ToString(Request.Form["name"]);
            _categoryService.Create(new Category { Name = categoryName });
            OnGet();
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
