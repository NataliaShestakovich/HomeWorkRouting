using HomeWorkRouting.Models.Population.DbModels.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace HomeWorkRouting.Models.Population.DbModels
{
    public class City : IGeoAgglomeration
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Population { get; set; }

        public Country Country { get; set; }
    }
}
