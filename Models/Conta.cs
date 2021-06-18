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
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Nome { get; set; }
        [Required]
        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Senha { get; set; }
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime? Dtn { get; set; }
        [Display(Name = "Gênero")]
        public string Genero { get; set; }
    }
}
