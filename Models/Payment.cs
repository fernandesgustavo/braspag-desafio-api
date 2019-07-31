using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Payment
    {
        [Required]
        public double ValorLiquido { get; set; }
    }
}