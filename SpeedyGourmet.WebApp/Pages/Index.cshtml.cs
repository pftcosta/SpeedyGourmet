using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<Recipe> Recipes { get; private set; }
        public Recipe Recipe { get; set; }
        public User User { get; set; }

        public void OnGet()
        {
            GetUser();
            Recipe = new Recipe();
            Recipes = new List<Recipe>();
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