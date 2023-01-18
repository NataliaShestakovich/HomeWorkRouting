using HomeWorkRouting.Models.Population.DbModels.Interfaces;
using HomeWorkRouting.Models.Population.ViewModels;
using HomeWorkRouting.Sevices;
using Microsoft.AspNetCore.Mvc;

namespace HomeWorkRouting.Controllers
{
    [Route("country")]
    public class CountryController : Controller
    {
        private readonly RepositoryService _service;

        private List<IGeoAgglomeration>? agglomerationData = new();

        public CountryController(RepositoryService service)
        {
            _service = service;
        }
        [HttpGet("{country}")]
        public IActionResult GetPopulation(string country)
        {
            agglomerationData = _service.Get(country);

            if (agglomerationData != null && agglomerationData.Count() != 0)
            {
                var countryModel = new FullResponce()
                {
                    GeoAgglomerations = agglomerationData
                };

                return View(countryModel);
            }
            else
            {
                return NotFound($"{country} is not found");
            }
        }

        [HttpGet("{country}/{**cities}")]
        public IActionResult GetPopulation(string country, string cities)
        {
            var citiesList = cities.Split('/').ToList();

            agglomerationData = _service.Get(country, citiesList);

            var errorCities = _service.GetErrorList();

            if (agglomerationData != null && agglomerationData.Count() != 0)
            {
                var countryModel = new FullResponce()
                {
                    Country = country,
                    GeoAgglomerations = agglomerationData,
                    ErrorList = errorCities
                };

                return View(countryModel);
            }
            else
            {
                return NotFound($"Data about the {country} - {cities} weren't found!");
            }
        }
    }
}
