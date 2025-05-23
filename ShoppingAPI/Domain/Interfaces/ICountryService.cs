using ShoppingAPI.DAL.Entities;

namespace ShoppingAPI.Domain.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountriesAsync();
        Task<Country> CreateCountryAsync(Country country);

    }
}
