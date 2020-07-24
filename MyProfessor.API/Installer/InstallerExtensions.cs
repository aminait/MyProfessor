using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MyProfessor.API.Installer
{
    public static class InstallerExtensions
    {
        public static void InstallServicesAssembly(this IServiceCollection services,IConfiguration configuration )
        {
            var installer = typeof(Startup).Assembly.ExportedTypes
                .Where(x=>
                typeof(IInstaller).IsAssignableFrom(x)&&!x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installer.ForEach(SingleInst => SingleInst.InstallServices(services, configuration));
        }


    }
}
