using LawСRM.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
            await _db.Database.EnsureDeletedAsync().ConfigureAwait(false);
            await _db.Database.MigrateAsync();

            if (await _db.Admins.AnyAsync()) return;

        }

        private Admin admin;
        private async Task InitializationAdmins()
        {
            admin = new Admin()
            {
                Login = "admin",
                Password = "admin"
            };
        }

        private AdminProfile adminProfile;
        private async Task InitializationAdminProfiles ()
        {
            adminProfile = new AdminProfile()
            {
                Email = "lawtoitstep@gmail.com",
                Name = "Тест",
                Surname = "Тестов",
                AdminId = admin.Id
            };
        }

        private const int _ClientCount=10;
        private Client[] _Clients;
        private async Task InitializationClients()
        {
            _Clients = new Client[_ClientCount];
            for (int i=0; i<_ClientCount; i++)
                _Clients[i] = new Client() 
                { 
                    Login=$"client {i+1}",
                    Password=$"clientPass {i+1}",
                };
        }

        private const int _IndividualClientCount = 6;
        private IndividualClientProfile[] _IndividualClients;
        private const int _IndividualCodeStart = 1111111111;
        private const int _PhoneNumber = 0630000000;
        
        private async Task InitializationIndividualClientsProfile()
        {
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
                    ClientId = _IndividualClients[i].Id
                };
        }

        private LegalOrganizationForms[] _LegalOrganizationForms;
        private async Task InitializeLegalOrganizationForms()
        {
            _LegalOrganizationForms = new LegalOrganizationForms[]
            {
                new LegalOrganizationForms{Name="Товариство з обмеженою відповідальністю"},
                new LegalOrganizationForms{Name="Акціонерне товариство"},
                new LegalOrganizationForms{Name="Приватне підприємство"},
                new LegalOrganizationForms{Name="Товариство з додатковою відповідальністю"}
            };
            await _db.LegalOrganizationForms.AddRangeAsync(_LegalOrganizationForms);
            await _db.SaveChangesAsync();
        }

        //private const int _LegalClientCount = 4;
        //private LegalClientProfile[] _LegalClients;
        //private const int _LegallCodeStart = 44444444;
        //private async Task InitializationLegalClientProfile()
        //{
        //    _LegalClients = new LegalClientProfile[_LegalClientCount];
        //    for (int i = _IndividualClientCount; i < _LegalClientCount; i++)
        //    {
        //        _LegalClients[i] = new LegalClientProfile()
        //        {
                    
        //        }
        //    }
        //}


    }
}
