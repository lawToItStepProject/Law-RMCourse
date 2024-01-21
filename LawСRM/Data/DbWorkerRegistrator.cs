using Microsoft.Extensions.DependencyInjection;
using LawСRM.Interfaces;
using LawСRM.Data.Entities;

namespace LawСRM.Data
{
    internal static class DbWorkerRegistrator
    {
        public static IServiceCollection AddDbWorkersInDb(this IServiceCollection services) => services
            .AddTransient<IDbWorker<Admin>, DbWorkerForAdmin>()
            .AddTransient<IDbWorker<AdminProfile>, DbWorker<AdminProfile>>()
            .AddTransient<IDbWorker<Client>, DbWorkerForClient>()
            .AddTransient<IDbWorker<IndividualClientProfile>, DbWorker<IndividualClientProfile>>()
            .AddTransient<IDbWorker<LegalOrganizationForms>, DbWorker<LegalOrganizationForms>>()
            .AddTransient<IDbWorker<LegalClientProfile>, DbWorkerForLegalClient>()
            ;
    }
}
