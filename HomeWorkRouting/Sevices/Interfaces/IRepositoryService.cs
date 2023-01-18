using HomeWorkRouting.Models.Population.DbModels.Interfaces;

namespace HomeWorkRouting.Sevices.Interfaces
{
    public interface IRepositoryService
    {
        List<IGeoAgglomeration>? Get(string nameCountry, List<string>? nameCities = null);
    }
}
