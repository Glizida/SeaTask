using System;
using System.Collections.Generic;

namespace WebAPISeaTask.ClassBD
{
    public partial class UserOwner
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int UserId { get; set; }
        public string? AccessLevel { get; set; }

        public virtual Organization Organization { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
