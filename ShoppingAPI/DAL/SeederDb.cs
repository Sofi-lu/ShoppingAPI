namespace ShoppingAPI.DAL
{
    public class SeederDb
    {
        private readonly DataBaseContext _context;

        public SeederDb(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeederAsync()
        { 
            await _context.Database.EnsureCreatedAsync();

            await PopulateCountriesAsync();

            await _context.SaveChangesAsync();
        }

        #region Private Methods

        private async Task PopulateCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Entities.Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Colombia",
                    States = new List<Entities.State>
                    {
                        new Entities.State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Antioquia"
                        },
                        new Entities.State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Caldas"
                        },
                        new Entities.State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Cundinamarca"
                        }
                    }
                });

                _context.Countries.Add(new Entities.Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Perú",
                    States = new List<Entities.State>
                    {
                        new Entities.State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Lima"
                        },
                        new Entities.State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Arequipa"
                        },
                        new Entities.State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Cusco"
                        }
                    }
                });

                _context.Countries.Add(new Entities.Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Argentina",
                    States = new List<Entities.State>
                    {
                        new Entities.State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Buenos Aires"
                        }
                    }
                });
            }
            
        }
        #endregion
    }
}
