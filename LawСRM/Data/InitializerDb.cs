using LawСRM.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawСRM.Data
{
    internal class InitializerDb
    {
        private readonly LawCRMDb _db;
        private readonly ILogger _Logger;
        public InitializerDb(LawCRMDb db, ILogger<InitializerDb> Logger)
        {
            _db = db;
            _Logger = Logger;
        }

        public async Task InitializeAsync()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация базы данных");
            _Logger.LogInformation("Удаление существующей БД");
            //Чтобы не возникало DeadLock, когда метод ожидает сам себя тут нужно разорвать контекст синхронизации и вызвать .ConfigureAwait(false);
            await _db.Database.EnsureDeletedAsync().ConfigureAwait(false);
            _Logger.LogInformation($"Удаление существующей БД выполнено за {timer.ElapsedMilliseconds} ");
            _Logger.LogInformation("Миграция БД");
            await _db.Database.MigrateAsync();
            _Logger.LogInformation($"Миграция БД выполнена за {timer.ElapsedMilliseconds} ");

            if (await _db.Admins.AnyAsync()) return;
            await InitializationAdmins();
            await InitializationAdminProfiles();
            await InitializationClients();
            await InitializationIndividualClientsProfile();
            await InitializeLegalOrganizationForms();
            await InitializationLegalClientProfile();
            _Logger.LogInformation($"Инициализация БД выполнена за {timer.Elapsed.TotalSeconds} ");
        }

        private Admin admin;
        private async Task InitializationAdmins()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация Администратора");
            admin = new Admin()
            {
                Login = "admin",
                Password = "admin"
            };
            await _db.Admins.AddAsync(admin);
            await _db.SaveChangesAsync();
            _Logger.LogInformation($"Инициализация Администратора выполнена за {timer.ElapsedMilliseconds} ");
        }

        private AdminProfile adminProfile;
        private async Task InitializationAdminProfiles ()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация ПрофиляАдминистратора");
            adminProfile = new AdminProfile()
            {
                Email = "lawtoitstep@gmail.com",
                Name = "Тест",
                Surname = "Тестов",
                AdminId = admin.Id
            };
            await _db.AdminProfiles.AddAsync(adminProfile);
            await _db.SaveChangesAsync();
            _Logger.LogInformation($"Инициализация ПрофиляАдминистратора выполнена за {timer.ElapsedMilliseconds} ");
        }

        private const int _ClientCount=11;
        private Client[] _Clients;
        private async Task InitializationClients()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация Клиентов");
            _Clients = new Client[_ClientCount];
            for (int i=0; i<_ClientCount; i++)
                _Clients[i] = new Client() 
                { 
                    Login=$"client{i+1}",
                    Password=$"clientPass{i+1}",
                };
            await _db.Clients.AddRangeAsync(_Clients);
            await _db.SaveChangesAsync();
            _Logger.LogInformation($"Инициализация Клиентов выполнена за {timer.ElapsedMilliseconds} ");
        }

        private const int _IndividualClientCount = 6;
        private IndividualClientProfile[] _IndividualClients;
        private int _IndividualCodeStart = 1111111111;
        private int _PhoneNumber = 0630000000;
        
        private async Task InitializationIndividualClientsProfile()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация Физических лиц");
            _IndividualClients = new IndividualClientProfile[_IndividualClientCount];
            for (int i=0; i < _IndividualClientCount; i++)
                _IndividualClients[i] = new IndividualClientProfile()
                {
                    Name = $"Клиент {i + 1}",
                    LastName = $"Отчество {i + 1}",
                    Surname = $"Фамилия {i + 1}",
                    RNOKPP = _IndividualCodeStart + i + 1,
                    PhoneNumber = _PhoneNumber + i + 1,
                    Email=$"client{i+1}@gmail.com",
                    ClientId = _Clients[i].Id
                };
            await _db.IndividualClients.AddRangeAsync(_IndividualClients);
            await _db.SaveChangesAsync();
            _Logger.LogInformation($"Инициализация Физических лиц выполнена за {timer.ElapsedMilliseconds} ");
        }

        private LegalOrganizationForms[] _LegalOrganizationForms;
        private async Task InitializeLegalOrganizationForms()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация ФормЮрлиц");
            _LegalOrganizationForms = new LegalOrganizationForms[]
            {
                new LegalOrganizationForms{Name="Товариство з обмеженою відповідальністю"},
                new LegalOrganizationForms{Name="Акціонерне товариство"},
                new LegalOrganizationForms{Name="Приватне підприємство"},
                new LegalOrganizationForms{Name="Товариство з додатковою відповідальністю"}
            };
            await _db.LegalOrganizationForms.AddRangeAsync(_LegalOrganizationForms);
            await _db.SaveChangesAsync();
            _Logger.LogInformation($"Инициализация ФормЮрЛиц выполнена за {timer.ElapsedMilliseconds} ");
        }

        private const int _LegalClientCount = 4;
        private LegalClientProfile[] _LegalClients;
        private int _LegallCodeStart = 44444444;
        private async Task InitializationLegalClientProfile()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация Юрлиц");
            _LegalClients = new LegalClientProfile[_LegalClientCount];
            int tmp = 0;
            int tmp2 = 6;
            for (int i = 0; i < _LegalClientCount; i++)
            {
                _LegalClients[i] = new LegalClientProfile()
                {
                    Name = $"Фирма {i+1}",
                    EDRPOU = _LegallCodeStart + 1 + i,
                    PhoneNumber = _PhoneNumber + 2 + i,
                    Email = $"firm{i + 1}@gmail.com",
                    LegalOrganizationFormId = _LegalOrganizationForms[tmp].Id,
                    ClientId = _Clients[tmp2].Id

                };
                tmp++;
                tmp2++;
                await _db.LegalClients.AddAsync(_LegalClients[i]);
                await _db.SaveChangesAsync();
                _Logger.LogInformation($"Инициализация ЮрЛиц выполнена за {timer.ElapsedMilliseconds} ");
            }
        }


    }
}
