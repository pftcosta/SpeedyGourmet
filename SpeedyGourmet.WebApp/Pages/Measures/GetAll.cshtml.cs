using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

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

        public void OnGet()
        {
            Measures = _measureService.GetAll();
        }

        public void OnPost()
        {
            string measureName = Convert.ToString(Request.Form["name"]);
            _measureService.Create( new Measure { Name = measureName });
            OnGet();
        }
    }
}
