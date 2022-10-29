using System;
using System.Collections.Generic;

namespace WebAPISeaTask.ClassBD
{
    public partial class Loginuser
    {
        public Loginuser()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
