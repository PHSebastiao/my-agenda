using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAgenda.Data;
using MyAgenda.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace MyAgenda.Controllers
{
    public class ContaEventosController : Controller
    {

        private readonly MyAgendaContext _context;

        public ContaEventosController(MyAgendaContext context)
        {
            _context = context;
        }

        // GET: ContaEventos/5
        public async Task<List<ContaEvento>> Index(int Idevento)
        {
            return await _context.ContaEvento.Where(ce => ce.IdEvento == Idevento).ToListAsync();
        }

        // POST: ContaEventos/Create
        [HttpPost]
        public async Task<IActionResult> Create(ContaEvento data)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            _context.Add(data);
            await _context.SaveChangesAsync();
            var contaEvento = _context.ContaEvento.FirstOrDefault(e => data.IdConta == e.IdConta && e.IdEvento == data.IdEvento);

            IQueryable<Conta> contas = _context.Conta.AsQueryable();
            IQueryable<ContaEvento> contaeventos = _context.ContaEvento.AsQueryable();
            var query = from c in contas
                        join ce in contaeventos
                        on c.Idconta equals ce.IdConta
                        where ce.IdContaEventos == contaEvento.IdContaEventos
                        select new ContaEventoDTO { Nome = c.Nome, Idconta = c.Idconta, IdContaEventos = ce.IdContaEventos };

            return Ok(query);
        }

        // POST: ContaEventos/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var contaEvento = await _context.ContaEvento.FindAsync(id);
            _context.ContaEvento.Remove(contaEvento);
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}
