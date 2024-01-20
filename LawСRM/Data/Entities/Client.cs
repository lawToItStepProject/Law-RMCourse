using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawСRM.Data.Entities
{
    public class Client:Entity
    {
        public string? Login { get; set; } 
        public string? Password { get; set; } 
        public virtual IndividualClientProfile? IndividualProfile { get; set; }
        public virtual LegalClientProfile? LegalProfile { get; set; }
    }
}
