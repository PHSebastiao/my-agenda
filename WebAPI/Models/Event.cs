using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Event
    {
        [Key]
        public int Idevent { get; internal set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Local { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
