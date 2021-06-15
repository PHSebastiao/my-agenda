using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyAgenda.Models
{
    public class Evento
    {
        [Key]
        public int Idevento { get; set; }
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public string Local { get; set; }
        [BindProperty]
        public string Tipo { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data { get ; set; }
    }
}
