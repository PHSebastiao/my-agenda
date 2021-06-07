using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContaEventosController : ControllerBase
    {
        private readonly AgendaDBContext _context;

        public ContaEventosController(AgendaDBContext context)
        {
            _context = context;
        }

        // GET: api/ContaEventos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContaEvento>>> GetContaEvento()
        {
            return await _context.ContaEvento.ToListAsync();
        }

        // GET: api/ContaEventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContaEvento>> GetContaEvento(int id)
        {
            var contaEvento = await _context.ContaEvento.FindAsync(id);

            if (contaEvento == null)
            {
                return NotFound();
            }

            return Ok(contaEvento);
        }

        // PUT: api/ContaEventos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContaEvento(int id, ContaEvento contaEvento)
        {
            if (id != contaEvento.IdContaEventos)
            {
                return BadRequest();
            }

            _context.Entry(contaEvento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContaEventoExists(id))
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

        // POST: api/ContaEventos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContaEvento>> PostContaEvento(ContaEvento contaEvento)
        {
            _context.ContaEvento.Add(contaEvento);
            await _context.SaveChangesAsync();

            return Ok(CreatedAtAction("GetContaEvento", new { id = contaEvento.IdContaEventos }, contaEvento));
        }

        // DELETE: api/ContaEventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContaEvento(int id)
        {
            var contaEvento = await _context.ContaEvento.FindAsync(id);
            if (contaEvento == null)
            {
                return NotFound();
            }

            _context.ContaEvento.Remove(contaEvento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContaEventoExists(int id)
        {
            return _context.ContaEvento.Any(e => e.IdContaEventos == id);
        }
    }
}
