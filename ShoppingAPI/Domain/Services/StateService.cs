using Microsoft.EntityFrameworkCore;
using ShoppingAPI.DAL;
using ShoppingAPI.DAL.Entities;
using ShoppingAPI.Domain.Interfaces;

namespace ShoppingAPI.Domain.Services
{
    public class StateService : IStateService
    {
        private readonly DataBaseContext _context;

        public StateService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<State>> GetStatesByCountryIdAsync(Guid countryId)
        {
            try
            {
                return await _context.States
                    .Include(s => s.Country)
                    .Where(s => s.CountryId == countryId)
                    .ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<State> GetStateByNameAsync(string name)
        {
            try
            {
                return await _context.States.Include(s => s.Country).FirstOrDefaultAsync(s => s.Name == name);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<State> CreateStateAsync(State state)
        {
            try
            {
                state.Id = Guid.NewGuid();
                state.CreatedDate = DateTime.Now;
                _context.States.Add(state);

                await _context.SaveChangesAsync();
                return state;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<State> EditStateAsync(State state)
        {
            try
            {
                state.ModifiedDate = DateTime.Now;
                _context.States.Update(state);

                await _context.SaveChangesAsync();
                return state;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<State> DeleteStateAsync(Guid id)
        {
            try
            {
                var state = await _context.States.FindAsync(id);
                if (state == null) return null;
                _context.States.Remove(state);

                await _context.SaveChangesAsync();
                return state;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

    }
}
