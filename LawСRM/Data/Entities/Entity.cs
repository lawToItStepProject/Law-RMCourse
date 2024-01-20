using LawСRM.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawСRM.Data.Entities
{
    public abstract class Entity:IEntity
    {
        public int Id { get; set; }
    }
}
