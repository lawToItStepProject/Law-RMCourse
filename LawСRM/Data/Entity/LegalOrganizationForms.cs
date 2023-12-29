using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawСRM.Data.Entity
{
    public class LegalOrganizationForms
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<LegalClientProfile> legalClientProfiles { get; set; }=new List<LegalClientProfile>();
    }
}
