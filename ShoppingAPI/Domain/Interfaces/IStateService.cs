using ShoppingAPI.DAL.Entities;

namespace ShoppingAPI.Domain.Interfaces
{
    public interface IStateService
    {
        Task<IEnumerable<State>> GetStatesByCountryIdAsync(Guid countryId);
        Task<State> GetStateByNameAsync(string name);
        Task<State> CreateStateAsync(State state);
        Task<State> EditStateAsync(State state);
        Task<State> DeleteStateAsync(Guid id);
    }
}
