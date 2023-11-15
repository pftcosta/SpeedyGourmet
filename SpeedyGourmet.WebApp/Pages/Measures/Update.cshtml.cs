using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Measures
{
    public class Update : PageModel
    {
        private readonly IService<Measure, int> _measureService;

        public Update(IService<Measure, int> measureService)
        {
            _measureService = measureService;
        }

        public Measure Measure { get; private set; }

        public void OnGet(int measureId)
        {
            Measure = _measureService.GetById(measureId);
        }

        public IActionResult OnPost()
        {
            Measure = new()
            {
                Id = Convert.ToInt32(Request.Form["id"]),
                Name = Convert.ToString(Request.Form["name"])
            };

            _measureService.Update(Measure);
            return Redirect("/Measures/GetAll");
        }
    }
}
