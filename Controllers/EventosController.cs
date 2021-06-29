using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAgenda.Data;
using MyAgenda.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAgenda.Controllers
{
    public class EventosController : Controller
    {
        private readonly MyAgendaContext _context;

        public EventosController(MyAgendaContext context)
        {
            _context = context;
        }

        // GET: Eventos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Evento.ToListAsync());
        }

        // GET: Eventos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Evento
                .FirstOrDefaultAsync(m => m.Idevento == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Eventos/Create
        public ViewResult Create()
        {
            IQueryable<Conta> contas = _context.Conta.AsQueryable();
            ViewData["Contas"] = contas;
            return View();
        }

        // POST: Eventos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idevento,Titulo,Descricao,Local,Tipo,Data")] Evento evento)
        {
            IQueryable<Conta> contas = _context.Conta.AsQueryable();

            if (VerificaMesmaData(evento))
            {
                TempData["message"] = "Dois eventos exclusivos não podem compartilhar a mesma data.";
                ViewData["Contas"] = contas;
                return View(evento);
            }

            if (ModelState.IsValid)
            {
                _context.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Contas"] = contas;
            return View(evento);
        }

        // GET: Eventos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Evento evento = await _context.Evento.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            IQueryable<Conta> contas = _context.Conta.AsQueryable();
            IQueryable<ContaEvento> contaeventos = _context.ContaEvento.AsQueryable();

            ViewData["Contas"] = await contas.ToListAsync();
            ViewData["ContaEventos"] = await GetContaEventos(contas, contaeventos, id).ToListAsync();
            //var contaEventosNomes = _context.ContaEvento.Include(x => x.Conta)
            //    .Where(x => x.IdEvento == id)
            //    .Select(x => new { x.Conta.Idconta, x.Conta.Nome });
            return View(evento);
        }

        // POST: Eventos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idevento,Titulo,Descricao,Local,Tipo,Data")] Evento evento)
        {
            if (id != evento.Idevento)
            {
                return NotFound();
            }

            IQueryable<Conta> contas = _context.Conta.AsQueryable();
            IQueryable<ContaEvento> contaeventos = _context.ContaEvento.AsQueryable();

            if (VerificaMesmaData(evento))
            {
                TempData["message"] = "Dois eventos exclusivos não podem compartilhar a mesma data.";
                ViewData["Contas"] = contas;
                ViewData["ContaEventos"] = await GetContaEventos(contas, contaeventos, id).ToListAsync();
                return Ok(evento);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.Idevento))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["Contas"] = contas.ToListAsync();
            ViewData["ContaEventos"] = await GetContaEventos(contas, contaeventos, id).ToListAsync();
            return View(evento);
        }

        // GET: Eventos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Evento
                .FirstOrDefaultAsync(m => m.Idevento == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evento = await _context.Evento.FindAsync(id);
            _context.Evento.Remove(evento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(int id)
        {
            return _context.Evento.Any(e => e.Idevento == id);
        }

        private bool VerificaMesmaData(Evento evento)
        {
            var eventosNaMesmaData = _context.Evento.Where(e => evento.Data == e.Data && e.Idevento != evento.Idevento);
            if (evento.Tipo == "Exclusivo" && eventosNaMesmaData.Any())
            {
                return true;
            }
            return false;
        }

        private IQueryable<ContaEventoDTO> GetContaEventos(IQueryable<Conta> contas, IQueryable<ContaEvento> contaeventos, int? id)
        {
            var query = from c in contas
                        join ce in contaeventos
                        on c.Idconta equals ce.IdConta
                        where ce.IdEvento == id
                        select new ContaEventoDTO { Nome = c.Nome, Idconta = c.Idconta, IdContaEventos = ce.IdContaEventos };
            return query;
        }
    }

}
