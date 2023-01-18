using HomeWorkRouting.Models.Population.DbModels.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace HomeWorkRouting.Models.Population.DbModels
{
    public class Country : IGeoAgglomeration
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Population { get; set; }

        public ICollection<City>? Cities { get; set; }
    }
}
