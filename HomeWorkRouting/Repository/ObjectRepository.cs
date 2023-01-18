using HomeWorkRouting.DBContext;
using HomeWorkRouting.Models.Population.DbModels;
using HomeWorkRouting.Models.Population.DbModels.Interfaces;
using HomeWorkRouting.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeWorkRouting.Repository
{
    public class ObjectRepository : IRepository
    {
        private readonly IDbContextFactory<PopulationContext> _dbContextFactory;

        public ObjectRepository(IDbContextFactory<PopulationContext> dbContextFactory)
        {
            _dbContextFactory= dbContextFactory;
        }

        public List<string> errorData { get; private set; }

        public List<IGeoAgglomeration>? Get(string nameCountry, List<string> nameCities = null)
        {
            List<IGeoAgglomeration> result = new();

            List<string> _errorData = new();

            if (nameCities == null)
            {
                Country? countryData = new();

                using (var _dbContext = _dbContextFactory.CreateDbContext())
                {   
                    countryData = _dbContext.Countries.AsNoTracking().
                        Where(b => b.Name == nameCountry).
                        FirstOrDefault();
                }

                if (countryData != null)
                {
                    result.Add(countryData);
                }
            }
           
            else
            {
                for (int i = 0; i < nameCities.Count(); i++)
                {
                    City? cityData = new City();
                    var cityName = nameCities[i];

                    using (var _dbContext = _dbContextFactory.CreateDbContext())
                    {
                        cityData = _dbContext.Cities.AsNoTracking().
                            Where(c => c.Name == cityName &&
                                  c.Country.Name == nameCountry).
                                  FirstOrDefault();

                        if (cityData != null)
                        {
                            result.Add(cityData);
                        }
                        else
                        {
                            _errorData.Add(nameCities[i]);
                        }
                    }                        
                }
            }

            errorData = _errorData;

            return result;
        }
    }
}
