using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MdrController : ControllerBase
    {
        // GET api/mdr
        [HttpGet]
        public ActionResult<List<Client>> Get()
        {
            // Taxas adquirente A
            Taxa taxaCliAVisa = new Taxa() { Bandeira = "Visa", Credito = 2.25, Debito = 2.00 };
            Taxa taxaCliAMaster = new Taxa() { Bandeira = "Master", Credito = 2.35, Debito = 1.98 };
            List<Taxa> taxasCliA = new List<Taxa>() { taxaCliAVisa, taxaCliAMaster };

            // Taxas adquirente B
            Taxa taxaCliBVisa = new Taxa() { Bandeira = "Visa", Credito = 2.50, Debito = 2.08 };
            Taxa taxaCliBMaster = new Taxa() { Bandeira = "Master", Credito = 2.65, Debito = 1.75 };
            List<Taxa> taxasCliB = new List<Taxa>() { taxaCliBVisa, taxaCliBMaster };

            // Taxas adquirente C
            Taxa taxaCliCVisa = new Taxa() { Bandeira = "Visa", Credito = 2.75, Debito = 2.16 };
            Taxa taxaCliCMaster = new Taxa() { Bandeira = "Master", Credito = 3.10, Debito = 1.58 };
            List<Taxa> taxasCliC = new List<Taxa>() { taxaCliCVisa, taxaCliCMaster };

            // Adquirente A
            Client cliA = new Client() { Adquirente = "Adquirente A", Taxas = taxasCliA };

            // Adquirente B
            Client cliB = new Client() { Adquirente = "Adquirente B", Taxas = taxasCliB };

            // Adquirente B
            Client cliC = new Client() { Adquirente = "Adquirente C", Taxas = taxasCliC };

            // Resultado final com todos os adquirentes
            List<Client> clients = new List<Client>() { cliA, cliB, cliC };

            return clients;
        }
    }
}