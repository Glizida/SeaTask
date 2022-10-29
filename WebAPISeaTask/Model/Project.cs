using System;
using System.Collections.Generic;

namespace WebAPISeaTask.ClassBD
{
    public partial class Project
    {
        public Project()
        {
            ProjectsOwners = new HashSet<ProjectsOwner>();
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string Header { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? LogoPath { get; set; }

        public virtual Organization Organization { get; set; } = null!;
        public virtual ICollection<ProjectsOwner> ProjectsOwners { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
