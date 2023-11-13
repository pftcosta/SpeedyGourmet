using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Measures
{
    public class Update : PageModel
    {
        private readonly IService<Measure, int> _measureService;

        public Update(IService<Measure, int> measureService, Measure measure)
        {
            _measureService = measureService;
            Measure = measure;
        }

        public Measure Measure { get; set; }

        public void OnGet(int id)
        {
            Measure = _measureService.GetById(id);
        }

        public IActionResult OnPost()
        {
            Measure.Id = Convert.ToInt32(Request.Form["id"]);
            Measure.Name = Convert.ToString(Request.Form["name"]);
            _measureService.Update(Measure);
            return Redirect("/Measures/GetAll");
        }
    }
}
