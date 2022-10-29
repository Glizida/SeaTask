using System;
using System.Collections.Generic;

namespace WebAPISeaTask.ClassBD
{
    public partial class TypeTask
    {
        public TypeTask()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
