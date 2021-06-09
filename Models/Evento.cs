using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAgenda.Models
{
    public class Evento
    {
        [Key]
        public int Idevento { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Local { get; set; }
        public string Tipo { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data { get ; set; }
    }
}
