using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Transaction
    {
        [Required]
        public double Valor { get; set; }
        [Required]
        public string Adquirente { get; set; }
        [Required]
        public string Bandeira { get; set; }
        [Required]
        public string Tipo { get; set; }
    }
}