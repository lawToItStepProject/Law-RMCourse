using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawСRM.Data.Entities
{
    public class AdminProfile:Entity
    {
        public string Email { get; set; } = null!;
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public int AdminId { get; set; }
        [ForeignKey(nameof(AdminId))]
        public virtual Admin? Admin { get; set; }
    }
}
