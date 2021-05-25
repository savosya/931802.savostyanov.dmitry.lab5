using System.ComponentModel.DataAnnotations;


namespace lab5.Models
{
    public class DoctorModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Speciality { get; set; }

        public int? HospitalId { get; set; }
        public HospitalModel Hospital { get; set; }
    }
}
