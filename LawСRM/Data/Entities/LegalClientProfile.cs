using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawСRM.Data.Entities
{
    public class LegalClientProfile:Entity
    {
        public string Name { get; set; } = null!;
        public int EDRPOU { get; set; }
        public long? PhoneNumber { get; set; }
        public string Email { get; set; }
        public int LegalOrganizationFormId { get; set; }

        [ForeignKey(nameof(LegalOrganizationFormId))]
        public virtual LegalOrganizationForms LegalOrganizationForm { get; set; } = null!;
        public int ClientId { get; set; }
        [ForeignKey(nameof (ClientId))]
        public virtual Client Client { get; set; } = null!;
    }
}
