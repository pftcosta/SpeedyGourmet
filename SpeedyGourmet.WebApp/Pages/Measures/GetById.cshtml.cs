using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;
using System.Text.Json;

namespace SpeedyGourmet.WebApp.Pages.Measures
{
    public class GetByIdModel : PageModel
    {
        private readonly IService<Measure, int> _measureService;

        public GetByIdModel(IService<Measure, int> measureService)
        {
            _measureService = measureService;
        }

        public Measure Measure { get; private set; }
        public User User { get; set; }

        public void OnGet(int measureId)
        {
            GetUser();
            Measure = _measureService.GetById(measureId);
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
