using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class AgendaDBContext : DbContext
    {
        public AgendaDBContext(DbContextOptions<AgendaDBContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Event { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<ContaEvento> ContaEvento { get; set; }
    }
}
