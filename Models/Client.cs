using System.Collections.Generic;

namespace api.Models
{
    public class Client
    {
        public string Adquirente { get; set; }
        public List<Taxa> Taxas { get; set; }
    }
}