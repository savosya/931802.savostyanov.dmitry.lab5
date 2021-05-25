using System.ComponentModel.DataAnnotations;


namespace lab5.Models
{
    public class LabModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
