using System.ComponentModel.DataAnnotations;

namespace MyAgenda.Models
{
    public class ContaEvento
    {
        [Key]
        public int IdContaEventos { get; set; }
        public int IdEvento { get; set; }
        //public Evento Evento { get; set; }
        public int IdConta { get; set; }
        //public Conta Conta { get; set; }
    }
}
