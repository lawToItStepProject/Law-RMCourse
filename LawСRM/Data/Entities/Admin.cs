using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawСRM.Data.Entities
{
    public class Admin : Entity
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public virtual AdminProfile? AdminProfile { get; set; }
    }
}
