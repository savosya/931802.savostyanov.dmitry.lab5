using System;
using System.ComponentModel.DataAnnotations;


namespace lab5.Models
{
    public class PatientModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        
        public string Description { get; set; }

    }
}
