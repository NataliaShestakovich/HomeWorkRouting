using HomeWorkRouting.Models.Population.DbModels.Interfaces;

namespace HomeWorkRouting.Repository.Interfaces
{
    public interface IRepository
    {
        List<IGeoAgglomeration>? Get(string nameCountry, List<string>? nameCities = null);
    }
}
