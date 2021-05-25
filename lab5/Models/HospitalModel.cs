using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace lab5.Models
{
    public class HospitalModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string Phones { get; set; }
        public ICollection<DoctorModel> Doctors { get; set; }
    }
}
