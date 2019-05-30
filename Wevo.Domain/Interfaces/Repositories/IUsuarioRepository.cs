using System;
using System.Collections.Generic;
using System.Text;
using Wevo.Domain.Entities.Domain;

namespace Wevo.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario ObterPorId(int idUsuario);
        IEnumerable<Usuario> ObterTodos();
        IEnumerable<Usuario> ObterPorTexto(string descricao);
        int Cadastrar(Usuario entity);
        bool Atualizar(Usuario entity);
        bool Remover(int idUsuario);
    }
}
