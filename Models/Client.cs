using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Client
    {
        [Required]
        public string Adquirente { get; set; }
        [Required]
        public List<Taxa> Taxas { get; set; }
    }
}