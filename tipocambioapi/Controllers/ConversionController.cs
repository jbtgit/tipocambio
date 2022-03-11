using Microsoft.AspNetCore.Mvc;
using TipoCambioAPI.Models;
using tipocambioapi.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TipoCambioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        private readonly tipocambioapiContext _context;

        public ConversionController(tipocambioapiContext context)
        {
            _context = context;
        }

        // GET: api/<TCController>
        [HttpGet("{idMonedaOrigen}/{idMonedaDestino}/{monto}")]
        public async Task<ActionResult<TCOutput>> Get(string idMonedaOrigen, string idMonedaDestino, decimal monto)
        {
            TCOutput output = new TCOutput();
            output.monedaOrigen = idMonedaOrigen;
            output.monedaDestino = idMonedaDestino;
            output.monto = monto;

            var tipoCambios = await _context.TipoCambio.ToListAsync();

            if (tipoCambios == null)
            {
                return NotFound();
            } else
            {
                foreach (var mon in from m in tipoCambios
                                  where m.idMonedaOrigen.Equals(idMonedaOrigen) && m.idMonedaDestino.Equals(idMonedaDestino)
                                  select new { m.valorTipoCambio })
                {
                    output.tipoCambio = mon.valorTipoCambio;
                    output.montoTipoCambio = monto * mon.valorTipoCambio;
                }
            }

            return output;
        }

        // GET api/<TCController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TCController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TCController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TCController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
