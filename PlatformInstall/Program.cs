using Microsoft.Extensions.DependencyInjection;
using PlaformInstall.Interfaces;
using PlaformInstall.Services;
using PlatformInstall.Interfaces;
using PlatformInstall.Services;

namespace PlatformInstall
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Configurar servi�os
            var serviceProvider = new ServiceCollection()
                .AddTransient<Inicio>()
                .AddTransient<ISaveIdentityService, SaveIdentityService>()
                .BuildServiceProvider();

            // Resolver e iniciar a aplica��o
            var inicio = serviceProvider.GetRequiredService<Inicio>();


            Application.Run(inicio);
        }
    }
}
