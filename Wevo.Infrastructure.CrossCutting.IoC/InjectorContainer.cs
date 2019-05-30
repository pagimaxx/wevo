using Wevo.AppService.Interfaces;
using Wevo.AppService.Service;
using Wevo.Domain.Interfaces.Repositories;
using Wevo.Domain.Interfaces.Services;
using Wevo.Domain.Services;
using Wevo.Persistence.Connection;
using Wevo.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Wevo.Infrastructure.CrossCutting.IoC
{
    public class InjectorContainer
    {
        public IServiceCollection ObterScopo(IServiceCollection interfaceService)
        {
            #region AppService

            interfaceService.AddScoped(typeof(IUsuarioAppService), typeof(UsuarioAppService));

            #endregion

            #region Service

            interfaceService.AddScoped(typeof(IUsuarioService), typeof(UsuarioService));

            #endregion

            #region Repository

            interfaceService.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));
            interfaceService.AddScoped(typeof(IConnectionDB), typeof(ConnectionDB));

            #endregion

            return interfaceService;
        }
    }
}
