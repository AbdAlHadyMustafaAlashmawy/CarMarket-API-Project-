using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day1.Model
{
    public class Car
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 
        [Required]
        public string Model { get; set; }
        [Required]
        public decimal price { get; set; }
        public string? Color { get; set; }

    }
}
