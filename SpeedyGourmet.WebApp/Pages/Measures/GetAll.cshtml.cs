using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Measures
{
    public class GetAll : PageModel
    {
        private readonly IService<Measure, int> _measureService;

        public GetAll(IService<Measure, int> measureService)
        {
            _measureService = measureService;
        }

        public List<Measure> Measures { get; private set; }
        public User User { get; set; }

        public void OnGet()
        {
            GetUser();
            Measures = _measureService.GetAll();
        }

        public void OnPost()
        {
            string measureName = Convert.ToString(Request.Form["name"]);
            _measureService.Create( new Measure { Name = measureName });
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
