using Microsoft.EntityFrameworkCore;
using MyAgenda.Models;

namespace MyAgenda.Data
{
    public class MyAgendaContext : DbContext
    {
        public MyAgendaContext (DbContextOptions<MyAgendaContext> options)
            : base(options)
        {
        }

        public DbSet<Conta> Conta { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<ContaEvento> ContaEvento { get; set; }
    }
}
