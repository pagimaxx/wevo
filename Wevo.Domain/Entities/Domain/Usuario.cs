using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Wevo.Infrastructure.CrossCutting.Utilities.Extension;

namespace Wevo.Domain.Entities.Domain
{
    [SqlFilter(SequenceName = "")]
    public partial class Usuario : BaseDominio
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [StringLength(400)]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [StringLength(16)]
        public string CPF { get; set; }

        [Display(Name = "Email")]
        [StringLength(150)]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(30)]
        public string Telefone { get; set; }

        [Display(Name = "Sexo")]
        [StringLength(2)]
        public string Sexo { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
    }
}
