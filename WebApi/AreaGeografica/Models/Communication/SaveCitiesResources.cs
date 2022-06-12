using System;
using System.ComponentModel.DataAnnotations;

namespace AreaGeografica.Models.Communication
{
    public class SaveCitiesResources
    {
        [Required]
        [MaxLength(50)]

        public string cities { get; set; }
        public int numeroAbitanti { set; get; }
        public int numeroPositivi { set; get; }

        public Cities toCities() => new Cities
        {
            cities = this.cities,
            numeroAbitanti = this.numeroAbitanti,
            numeroPositivi = this.numeroPositivi
        };
    }
}
