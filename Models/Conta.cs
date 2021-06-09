using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAgenda.Models
{
    public class Conta
    {
        [Key]
        public int Idconta { get; set; }
        public string Nome { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Senha { get; set; }
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime Dtn { get; set; }
        public string Genero { get; set; }
    }
}
