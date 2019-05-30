using System;
using System.ComponentModel.DataAnnotations;

namespace Wevo.AppService.ViewModels.Alteracao
{
    public class UsuarioAlteracaoViewModel
    {
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [StringLength(500, ErrorMessage = "Tamanho não Permitido")]
        public string Nome { get; set; }

        /// <summary>
        /// CPF
        /// </summary>
        [StringLength(16, ErrorMessage = "Tamanho não Permitido")]
        public string CPF { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [StringLength(150, ErrorMessage = "Tamanho não Permitido")]
        public string Email { get; set; }

        /// <summary>
        /// Telefone
        /// </summary>
        [StringLength(30, ErrorMessage = "Tamanho não Permitido")]
        public string Telefone { get; set; }

        /// <summary>
        /// Sexo (M/F)
        /// </summary>
        [StringLength(2, ErrorMessage = "Tamanho não Permitido")]
        public string Sexo { get; set; }

        /// <summary>
        /// Dara de Nascimento
        /// </summary>
        public DateTime DataNascimento { get; set; }
    }
}
