using AspNetCorePractice.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace MyPracticeProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IPersonsService _personsService;
        private readonly IGenderService _genderService;
        public HomeController(ICountryService countryService, IPersonsService personsService, IGenderService genderService)
        {
            _countryService= countryService;
            _personsService= personsService;
            _genderService= genderService;
        }
        [HttpGet("/index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("/persons")]
        public ActionResult GetPersons()
        {
            var persons = _personsService.GetPersons();
            return View(persons);
        }

        [HttpGet("/countries")]
        public ActionResult GetCountries()
        {
            var countries = _countryService.GetCountries();
            return View(countries);
        }

        [HttpGet("/genders")]
        public ActionResult GetGenders()
        {
            var genders = _genderService.GetGenders();
            return View(genders);
        }
    }
}
