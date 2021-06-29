using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        //public virtual ICollection<ContaEvento> ContaEventos { get; set; }

        public static implicit operator Conta(List<Conta> v)
        {
            throw new NotImplementedException();
        }
    }
}
