using AutoMapper;
using Wevo.AppService.Interfaces;
using Wevo.AppService.ViewModels.Alteracao;
using Wevo.AppService.ViewModels.Consulta;
using Wevo.AppService.ViewModels.Inclusao;
using Wevo.Domain.Entities.Domain;
using Wevo.Domain.Interfaces.Services;
using Wevo.Infrastructure.CrossCutting.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wevo.AppService.Service
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _IUsuarioService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="usuarioService"></param>
        public UsuarioAppService(IUsuarioService usuarioService)
        {
            _IUsuarioService = usuarioService;
        }

        public string Atualizar(UsuarioAlteracaoViewModel usuario, int idUsuario)
        {
            var cb = MapperUtils.Map<UsuarioAlteracaoViewModel, Usuario>(usuario);
            cb.IdUsuarioAlteracao = idUsuario;
            return _IUsuarioService.Atualizar(cb).ToString();
        }

        public string Cadastrar(UsuarioInclusaoViewModel Usuario, int idUsuario)
        {
            var cb = MapperUtils.Map<UsuarioInclusaoViewModel, Usuario>(Usuario);
            cb.IdUsuarioCadastro = idUsuario;
            return _IUsuarioService.Cadastrar(cb).ToString();
        }

        public UsuarioConsultaViewModel ObterPorId(int idUsuario) =>
            MapperUtils.Map<Usuario, UsuarioConsultaViewModel>(_IUsuarioService.ObterPorId(idUsuario));

        public IEnumerable<UsuarioConsultaViewModel> ObterPorTexto(string texto) =>
            MapperUtils.MapList<Usuario, UsuarioConsultaViewModel>(_IUsuarioService.ObterPorTexto(texto));

        public IEnumerable<UsuarioConsultaViewModel> ObterTodos() =>
            MapperUtils.MapList<Usuario, UsuarioConsultaViewModel>(_IUsuarioService.ObterTodos());

        public bool Remover(int idUsuario) =>
            _IUsuarioService.Remover(idUsuario);
    }
}
