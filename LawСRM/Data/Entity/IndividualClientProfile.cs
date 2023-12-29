using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawСRM.Data.Entity
{
    public class IndividualClientProfile
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? LastName { get; set; }
        public string Surname { get; set; } = null!;
        public long RNOKPP { get; set; }
        public long? PhoneNumber { get; set; }
        public string Email { get; set; }
        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public virtual Client? Client { get; set; } = null!;
    }
}
