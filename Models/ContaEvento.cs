using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ContaEvento
    {
        [Key]
        public int IdContaEventos { get; set; }
        public int IdEvento { get; set; }
        public int IdConta { get; set; }
    }
}
