using HomeWorkRouting.Models.Population.DbModels.Interfaces;

namespace HomeWorkRouting.Models.Population.ViewModels
{
    public class FullResponce
    {
        public string Country { get; set; }
        public ICollection<IGeoAgglomeration> GeoAgglomerations { get; set; }
        public ICollection<string>? ErrorList { get; set; }
    }
}
