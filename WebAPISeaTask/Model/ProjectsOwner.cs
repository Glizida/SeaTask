using System;
using System.Collections.Generic;

namespace WebAPISeaTask.ClassBD
{
    public partial class ProjectsOwner
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectsId { get; set; }

        public virtual Project Projects { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
