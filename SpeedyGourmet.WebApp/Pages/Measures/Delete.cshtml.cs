using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Measures
{
    public class Delete : PageModel
    {
        private readonly IService<Measure, int> _measuretService;

        public Delete(IService<Measure, int> measuretService)
        {
            _measuretService = measuretService;
        }
        public User User { get; set; }

        public IActionResult OnGet(int measureId)
        {
            GetUser();
            _measuretService.Delete(measureId);
            return Redirect("/Measures/GetAll");
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
