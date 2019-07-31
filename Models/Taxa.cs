using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Taxa
    {
        [Required]
        public string Bandeira { get; set; }
        [Required]
        public double Credito { get; set; }
        [Required]
        public double Debito { get; set; }
    }
}