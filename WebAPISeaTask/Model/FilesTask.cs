using System;
using System.Collections.Generic;

namespace WebAPISeaTask.ClassBD
{
    public partial class FilesTask
    {
        public int Id { get; set; }
        public string PathFiles { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int TaskId { get; set; }

        public virtual Task Task { get; set; } = null!;
    }
}
