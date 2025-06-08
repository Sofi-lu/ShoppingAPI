using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.DAL.Entities;
using ShoppingAPI.Domain.Interfaces;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }


        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountriesAsync()
        {
            var countries = await _countryService.GetCountriesAsync();
            if (countries == null || !countries.Any())
            {
                return NotFound();
            }
            return Ok(countries);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Country>> GetCountryByIdAsync(Guid id)
        {
            var country = await _countryService.GetCountryByIdAsync(id);

            if (country == null) return NotFound();
            
            return Ok(country);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Country>> CreateCountryAsync(Country country)
        {
            try 
            {
                var newCountry = await _countryService.CreateCountryAsync(country);
                if (newCountry == null) return NotFound();
                return Ok(newCountry);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("[0] ya existe", country.Name));
                }
                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]

        public async Task<ActionResult<Country>> EditCountryAsync(Country country)
        {
            try
            {
                var updatedCountry = await _countryService.EditCountryAsync(country);
                if (updatedCountry == null) return NotFound();
                return Ok(updatedCountry);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("[0] ya existe", country.Name));
                }
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]

        public async Task<ActionResult<Country>> DeleteCountryAsync(Guid id)
        {
            if(id == null) return BadRequest();
            var deleteCountry = await _countryService.DeleteCountryAsync(id);
            if (deleteCountry == null) return NotFound();
            return Ok(deleteCountry);
            
        }

    }
}
