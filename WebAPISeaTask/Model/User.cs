using System;
using System.Collections.Generic;

namespace WebAPISeaTask.ClassBD
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            ProjectsOwners = new HashSet<ProjectsOwner>();
            TasksUsers = new HashSet<TasksUser>();
            TimeRecordings = new HashSet<TimeRecording>();
            UserOrganizations = new HashSet<UserOrganization>();
            UserOwners = new HashSet<UserOwner>();
        }

        public int Id { get; set; }
        public int LoginuserId { get; set; }
        public bool? Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DisplayName { get; set; }
        public string EmailAddress { get; set; } = null!;
        public string? AccessLevel { get; set; }
        public string? AvatarPath { get; set; }
        public DateTime? LastLogin { get; set; }
        public int? TelegramBotId { get; set; }

        public virtual Loginuser Loginuser { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ProjectsOwner> ProjectsOwners { get; set; }
        public virtual ICollection<TasksUser> TasksUsers { get; set; }
        public virtual ICollection<TimeRecording> TimeRecordings { get; set; }
        public virtual ICollection<UserOrganization> UserOrganizations { get; set; }
        public virtual ICollection<UserOwner> UserOwners { get; set; }
    }
}
