using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Wevo.Domain.Entities.Domain;
using Wevo.Domain.Interfaces.Repositories;
using Wevo.Domain.Interfaces.Services;

namespace Wevo.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool Atualizar(Usuario usuario)
        {
            using (var scope = new TransactionScope())
            {
                var listaUsuario = _usuarioRepository.ObterPorTexto(usuario.Nome);

                if (listaUsuario.Any(l => l.Id == usuario.Id))
                    return true;

                else if (listaUsuario.Any(l => l.Id != usuario.Id))
                    throw new Exception("Nome já cadastrado");
                else
                {
                    var result = false;
                    result = _usuarioRepository.Atualizar(usuario);

                    if (!result)
                        throw new Exception("Ocorreu um erro ao atualizar o usuário");

                    scope.Complete();
                    return result;
                }
            }
        }

        public int Cadastrar(Usuario usuario)
        {
            using (var scope = new TransactionScope())
            {
                if (_usuarioRepository.ObterPorTexto(usuario.Nome).Any())
                    throw new Exception("Nome já cadastrado");
                usuario.DataCadastro = DateTime.Now;
                var identificador = _usuarioRepository.Cadastrar(usuario);
                scope.Complete();
                return identificador;
            }
        }

        public Usuario ObterPorId(int idUsuario)
        {
            return _usuarioRepository.ObterPorId(idUsuario);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _usuarioRepository.ObterTodos();
        }

        public IEnumerable<Usuario> ObterPorTexto(string texto)
        {
            return _usuarioRepository.ObterPorTexto(texto);
        }

        public bool Remover(int idUsuario)
        {
            using (var scope = new TransactionScope())
            {
                return _usuarioRepository.Remover(idUsuario);
            }
        }
    }
}
