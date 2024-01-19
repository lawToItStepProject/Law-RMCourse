using LawСRM.Data;
using LawСRM.Services;
using LawСRM.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace LawСRM
{

    public partial class App : Application
    {
        //Описываем хост, используя паттерн Singleton (первое обращение к статическому свойству заставит хост создаться
        //с помощью метода CreateHostBuilder, а все последующие обращения будут переадресованы к полю, которое будет заполнено
        //при первом обращении к нему
        private static IHost _Host;

        private static IHost Host=>_Host??=Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        //Создаем метод для доступа к сервисам через хост. Таким образом первое обращение к этому свойству приведет к созданию хоста
        public static IServiceProvider Services => _Host.Services;
        //Cоздаем метод, в котором будем конфиругировать сервисы приложения
        internal static void ConfigureServices(HostBuilderContext context, IServiceCollection services) => services
            .AddServices()
            .AddViewModels()
            .AddDatabase(context.Configuration.GetSection("Database"))
            ;

        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;
            base.OnStartup(e);
            await host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Host;
            base.OnExit(e);
            await host.StopAsync();
        }
    }

}
