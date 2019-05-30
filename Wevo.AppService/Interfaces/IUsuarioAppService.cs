using System.Collections.Generic;
using Wevo.AppService.ViewModels.Alteracao;
using Wevo.AppService.ViewModels.Consulta;
using Wevo.AppService.ViewModels.Inclusao;

namespace Wevo.AppService.Interfaces
{
    public interface IUsuarioAppService
    {
        UsuarioConsultaViewModel ObterPorId(int idUsuario);
        IEnumerable<UsuarioConsultaViewModel> ObterTodos();
        IEnumerable<UsuarioConsultaViewModel> ObterPorTexto(string texto);
        string Cadastrar(UsuarioInclusaoViewModel Usuario, int idUsuario);
        string Atualizar(UsuarioAlteracaoViewModel Usuario, int idUsuario);
        bool Remover(int idUsuario);
    }
}
