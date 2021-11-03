using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public abstract class EntityBase
    {
        public string Id { get; set; }

        public EntityBase()
        {
            Guid id = Guid.NewGuid();
            Id = Convert.ToString(id);
        }
    }
}
