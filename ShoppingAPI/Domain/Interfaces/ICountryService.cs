using ShoppingAPI.DAL.Entities;

namespace ShoppingAPI.Domain.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountriesAsync();
        Task<Country> CreateCountryAsync(Country country);

        Task<Country> GetCountryById(Guid id);

        Task<Country> EditCountryAsync(Country country);

        Task<bool> DeleteCountryAsync(Guid id);

    }
}
