using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Measures
{
    public class GetAllModel : PageModel
    {
        private readonly IService<Measure, int> _measureService;

        public GetAllModel(IService<Measure, int> measureService)
        {
            _measureService = measureService;
        }

        public List<Measure> measures { get; set; }

        public Measure measure = new();

        public void OnGet()
        {
            measures = _measureService.GetAll();
        }

        public void OnPost()
        {
            measure.Name = Convert.ToString(Request.Form["name"]);
            _measureService.Create(measure);
            OnGet();
        }
    }
}
