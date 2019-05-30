using System;

namespace Wevo.AppService.ViewModels.Consulta
{
    public class UsuarioConsultaViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// CPF
        /// </summary>
        public string CPF { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Telefone
        /// </summary>
        public string Telefone { get; set; }

        /// <summary>
        /// Sexo (M/F)
        /// </summary>
        public string Sexo { get; set; }

        /// <summary>
        /// Dara de Nascimento
        /// </summary>
        public DateTime DataNascimento { get; set; }
    }
}
