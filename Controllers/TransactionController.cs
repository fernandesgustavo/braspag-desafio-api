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
    public class TransactionController : ControllerBase
    {   
        private Payment payment;
        private Transaction transaction;

        // POST api/transaction
        [HttpPost]
        public ActionResult<Payment> Create([FromBody] Transaction tran)
        {
            if (tran.Adquirente == null | tran.Bandeira == null | tran.Tipo == null | tran.Valor <= 0)
            {
                return BadRequest();
            }

            this.transaction = ToUpper(tran);

            this.payment = new Payment();
                
            switch (this.transaction.Adquirente)
            {
                case "A":
                    switch (this.transaction.Bandeira)
                    {
                        case "VISA":
                            switch (this.transaction.Tipo)
                            {
                                case "CREDITO":
                                    this.payment.ValorLiquido = GetLiquid(this.transaction.Valor, 0.0225);
                                    break;

                                case "DEBITO":
                                    this.payment.ValorLiquido = GetLiquid(this.transaction.Valor, 0.02);
                                    break;
                                default:
                                    return BadRequest();
                            }
                            break;

                        case "MASTER":
                            switch (this.transaction.Tipo)
                            {
                                case "CREDITO":
                                    this.payment.ValorLiquido = GetLiquid(this.transaction.Valor, 0.0235);
                                    break;

                                case "DEBITO":
                                    this.payment.ValorLiquido = GetLiquid(this.transaction.Valor, 0.0198);
                                    break;
                                default:
                                    return BadRequest();
                            }
                            break;
                        
                        default:
                            return BadRequest();
                    }
                    break;             

                case "B":
                    switch (this.transaction.Bandeira)
                    {
                        case "VISA":
                            switch (this.transaction.Tipo)
                            {
                                case "CREDITO":
                                    this.payment.ValorLiquido = GetLiquid(this.transaction.Valor, 0.025);
                                    break;

                                case "DEBITO":
                                    this.payment.ValorLiquido = GetLiquid(this.transaction.Valor, 0.0208);
                                    break;
                                default:
                                    return BadRequest();
                            }
                            break;

                        case "MASTER":
                            switch (this.transaction.Tipo)
                            {
                                case "CREDITO":
                                    this.payment.ValorLiquido = GetLiquid(this.transaction.Valor, 0.0265);
                                    break;

                                case "DEBITO":
                                    this.payment.ValorLiquido = GetLiquid(this.transaction.Valor, 0.0175);
                                    break;
                                default:
                                    return BadRequest();
                            }
                            break;
                        
                        default:
                            return BadRequest();
                    }
                    break;

                case "C":
                    switch (this.transaction.Bandeira)
                    {
                        case "VISA":
                            switch (this.transaction.Tipo)
                            {
                                case "CREDITO":
                                    this.payment.ValorLiquido = GetLiquid(this.transaction.Valor, 0.0275);
                                    break;

                                case "DEBITO":
                                    this.payment.ValorLiquido = GetLiquid(this.transaction.Valor, 0.0216);
                                    break;
                                default:
                                    return BadRequest();
                            }
                            break;

                        case "MASTER":
                            switch (this.transaction.Tipo)
                            {
                                case "CREDITO":
                                    this.payment.ValorLiquido = GetLiquid(this.transaction.Valor, 0.031);
                                    break;

                                case "DEBITO":
                                    this.payment.ValorLiquido = GetLiquid(this.transaction.Valor, 0.0158);
                                    break;
                                default:
                                    return BadRequest();
                            }
                            break;
                        
                        default:
                            return BadRequest();
                    }
                    break;

                default:
                    return BadRequest();
            }

            return this.payment;
        }

        public double GetLiquid(double total, double indice)
        {
            return Math.Round((total - (indice * total)), 2);
        }

        public Transaction ToUpper(Transaction tran)
        {
            tran.Adquirente = tran.Adquirente.ToUpper();
            tran.Bandeira = tran.Bandeira.ToUpper();
            tran.Tipo = tran.Tipo.ToUpper();

            return tran;
        }
    }
}