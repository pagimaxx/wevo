using Wevo.Api.Attributes;
using Wevo.AppService.Interfaces;
using Wevo.AppService.ViewModels.Alteracao;
using Wevo.AppService.ViewModels.Consulta;
using Wevo.AppService.ViewModels.Inclusao;
using Wevo.Infrastructure.CrossCutting.Enums;
using Wevo.Infrastructure.CrossCutting.Utilities.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace Wevo.Api.Controllers
{
    /// <summary>
    /// API Usuario
    /// </summary>
    [Route("usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService AppService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="iUsuarioAppServico"></param>
        public UsuarioController(IUsuarioAppService iUsuarioAppServico)
        {
            AppService = iUsuarioAppServico;
        }

        #region Métodos

        /// <summary>
        /// Obtém informações dos usuários
        /// </summary>
        /// <param name="idUsuario">Código do Tipo de Suspensão de Usuário</param>
        /// <returns>Informações do usuário</returns>
        [HttpGet]
        [Route("obter-por-id")]
        public ResultadoPesquisa<UsuarioConsultaViewModel> ObterPorId(int idUsuario) =>
            new ResultadoPesquisa<UsuarioConsultaViewModel> { Resultado = AppService.ObterPorId(idUsuario) };

        /// <summary>
        /// Obtém a lista de todos usuários
        /// </summary>
        /// <returns>Retorna a lista de todos os usuários</returns>
        [HttpGet]
        [Route("obter-todos")]
        public ResultadoPesquisa<IEnumerable<UsuarioConsultaViewModel>> ObterTodos() =>
            new ResultadoPesquisa<IEnumerable<UsuarioConsultaViewModel>> { Resultado = AppService.ObterTodos() };

        /// <summary>
        /// Obtém a lista de todos usuários por texto (busca)
        /// </summary>
        /// <returns>Retorna a lista de todos os usuários por texto (busca)</returns>
        [HttpGet]
        [Route("obter-por-texto")]
        public ResultadoPesquisa<IEnumerable<UsuarioConsultaViewModel>> ObterPorTexto(string texto) =>
            new ResultadoPesquisa<IEnumerable<UsuarioConsultaViewModel>> { Resultado = AppService.ObterPorTexto(texto) };


        /// <summary>
        /// Cadastrar Novo Usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="idUsuario"></param>
        /// <returns>Cadastrar novo usuário</returns>
        [HttpPost]
        [Route("cadastrar")]
        public ResultadoOperacao Cadastrar(UsuarioInclusaoViewModel usuario, int idUsuario) =>
            new ResultadoOperacao { Identificador = AppService.Cadastrar(usuario, idUsuario).ToString(), Sucesso = true };

        /// <summary>
        /// Atualizar o Usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="idUsuario"></param>
        /// <returns>Atualizar o usuário</returns>
        [HttpPut]
        [Route("atualizar")]
        public ResultadoOperacao Atualizar(UsuarioAlteracaoViewModel usuario, int idUsuario)
        {
            var result = AppService.Atualizar(usuario, idUsuario);
            return new ResultadoOperacao { Identificador = usuario.Id.ToString(), Sucesso = (result.ToLower() == "true" ? true : false) };
        }

        /// <summary>
        /// Remover o Usuário
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("remover")]
        public ResultadoOperacao Remover(int idUsuario)
        {
            var resultado = false;
            resultado = AppService.Remover(idUsuario);
            return new ResultadoOperacao { Identificador = idUsuario.ToString(), Sucesso = resultado };
        }

        #endregion  
    }
}