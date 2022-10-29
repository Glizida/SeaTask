using System;
using System.Collections.Generic;

namespace WebAPISeaTask.ClassBD
{
    public partial class Task
    {
        public Task()
        {
            Comments = new HashSet<Comment>();
            FilesTasks = new HashSet<FilesTask>();
            InverseMainTask = new HashSet<Task>();
            TasksUsers = new HashSet<TasksUser>();
            TimeRecordings = new HashSet<TimeRecording>();
        }

        public int Id { get; set; }
        public bool SubTask { get; set; }
        public int? MainTaskId { get; set; }
        public int ProjectsId { get; set; }
        public int UserOwnerId { get; set; }
        public string? Description { get; set; }
        public int TypeId { get; set; }
        public string Header { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public DateTime? CompleteTime { get; set; }

        public virtual Task? MainTask { get; set; }
        public virtual Project Projects { get; set; } = null!;
        public virtual TypeTask Type { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<FilesTask> FilesTasks { get; set; }
        public virtual ICollection<Task> InverseMainTask { get; set; }
        public virtual ICollection<TasksUser> TasksUsers { get; set; }
        public virtual ICollection<TimeRecording> TimeRecordings { get; set; }
    }
}
