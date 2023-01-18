using HomeWorkRouting.Models.Population.DbModels.Interfaces;
using HomeWorkRouting.Repository;
using HomeWorkRouting.Sevices.Interfaces;

namespace HomeWorkRouting.Sevices
{
    public class RepositoryService : IRepositoryService
    {
        private readonly ObjectRepository _repository;

        public RepositoryService(ObjectRepository repository)
        {
            _repository = repository as ObjectRepository;
        }
        
        public List<string>? GetErrorList()
        {
            return _repository.errorData;
        }

        public List<IGeoAgglomeration>? Get(string nameCountry, List<string> nameCities = null)
        {
            return _repository.Get(nameCountry, nameCities);
        }
    }
}
