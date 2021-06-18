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
        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Required]
        [StringLength(600)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Local { get; set; }
        [Required]
        [BindProperty]
        public string Tipo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Data { get ; set; }
    }
}
