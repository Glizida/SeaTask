using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPISeaTask.ClassBD
{
    public partial class Country
    {
        
        public Country()
        {
            Organizations = new HashSet<Organization>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Organization> Organizations { get; set; }
    }
}
