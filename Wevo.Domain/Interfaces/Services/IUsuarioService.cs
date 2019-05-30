using System.Collections.Generic;
using Wevo.Domain.Entities.Domain;

namespace Wevo.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Usuario ObterPorId(int idUsuario);
        IEnumerable<Usuario> ObterTodos();
        IEnumerable<Usuario> ObterPorTexto(string texto);
        int Cadastrar(Usuario usuario);
        bool Atualizar(Usuario usuario);
        bool Remover(int idUsuario);
    }
}
