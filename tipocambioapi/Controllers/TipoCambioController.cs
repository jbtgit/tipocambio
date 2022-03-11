#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TipoCambioAPI.Models;
using tipocambioapi.Data;

namespace tipocambioapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCambioController : ControllerBase
    {
        private readonly tipocambioapiContext _context;

        public TipoCambioController(tipocambioapiContext context)
        {
            _context = context;
        }

        // GET: api/TipoCambio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCambio>>> GetTipoCambio()
        {
            return await _context.TipoCambio.ToListAsync();
        }

        // GET: api/TipoCambio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoCambio>> GetTipoCambio(int id)
        {
            var tipoCambio = await _context.TipoCambio.FindAsync(id);

            if (tipoCambio == null)
            {
                return NotFound();
            }

            return tipoCambio;
        }

        // PUT: api/TipoCambios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}")]
        public async Task<IActionResult> PostTipoCambio(int id, TipoCambio tipoCambio)
        {
            if (id != tipoCambio.idTipoCambio)
            {
                return BadRequest();
            }

            _context.Entry(tipoCambio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoCambioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TipoCambio
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoCambio>> PostTipoCambio(TipoCambio tipoCambio)
        {
            _context.TipoCambio.Add(tipoCambio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoCambio", new { id = tipoCambio.idTipoCambio }, tipoCambio);
        }

        // DELETE: api/TipoCambio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoCambio(int id)
        {
            var tipoCambio = await _context.TipoCambio.FindAsync(id);
            if (tipoCambio == null)
            {
                return NotFound();
            }

            _context.TipoCambio.Remove(tipoCambio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoCambioExists(int id)
        {
            return _context.TipoCambio.Any(e => e.idTipoCambio == id);
        }
    }
}
