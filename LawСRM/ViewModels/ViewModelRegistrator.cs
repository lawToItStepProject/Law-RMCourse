using LawСRM.ViewModels.ViewModelsToAdmins;
using LawСRM.ViewModels.ViewModelsClients;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LawСRM.ViewModels
{
    internal static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            .AddTransient<AdminWindowViewModel>()
            .AddTransient<IdividualClientsViewModel>()
            ;
    }
}
