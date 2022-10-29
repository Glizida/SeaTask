using System;
using System.Collections.Generic;

namespace WebAPISeaTask.ClassBD
{
    public partial class TimeRecording
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public string? Description { get; set; }

        public virtual Task Task { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
