using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAPISeaTask.ClassBD;

namespace WebAPISeaTask
{
    public partial class master_bdContext : DbContext
    {
        public master_bdContext()
        {
           
        }

        public master_bdContext(DbContextOptions<master_bdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<FilesTask> FilesTasks { get; set; } = null!;
        public virtual DbSet<Loginuser> Loginusers { get; set; } = null!;
        public virtual DbSet<Organization> Organizations { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectsOwner> ProjectsOwners { get; set; } = null!;
        public virtual DbSet<ClassBD.Task> Tasks { get; set; } = null!;
        public virtual DbSet<TasksUser> TasksUsers { get; set; } = null!;
        public virtual DbSet<TimeRecording> TimeRecordings { get; set; } = null!;
        public virtual DbSet<TypeTask> TypeTasks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserOrganization> UserOrganizations { get; set; } = null!;
        public virtual DbSet<UserOwner> UserOwners { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=master_bd;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("COMMENTS");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.TaskId).HasColumnName("TASK_ID");

                entity.Property(e => e.Text)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TEXT");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMMENTS_TASKS");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMMENTS_USER");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("COUNTRY");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(36)
                    .HasColumnName("NAME")
                    .IsFixedLength();
            });

            modelBuilder.Entity<FilesTask>(entity =>
            {
                entity.ToTable("FILES_TASKS");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("NAME")
                    .IsFixedLength();

                entity.Property(e => e.PathFiles)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PATH_FILES");

                entity.Property(e => e.TaskId).HasColumnName("TASK_ID");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.FilesTasks)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FILES_TASKS_TASKS");
            });

            modelBuilder.Entity<Loginuser>(entity =>
            {
                entity.ToTable("LOGINUSER");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Login)
                    .HasMaxLength(12)
                    .HasColumnName("LOGIN")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(32)
                    .HasColumnName("PASSWORD")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("ORGANIZATION");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AddressLegal)
                    .HasMaxLength(50)
                    .HasColumnName("ADDRESS_LEGAL");

                entity.Property(e => e.CountryId).HasColumnName("COUNTRY_ID");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(10)
                    .HasColumnName("EMAIL_ADDRESS")
                    .IsFixedLength();

                entity.Property(e => e.LogoPath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LOGO_PATH");

                entity.Property(e => e.NameFull)
                    .HasMaxLength(20)
                    .HasColumnName("NAME_FULL")
                    .IsFixedLength();

                entity.Property(e => e.NameShort)
                    .HasMaxLength(10)
                    .HasColumnName("NAME_SHORT")
                    .IsFixedLength();

                entity.Property(e => e.UnpInn).HasColumnName("UNP_INN");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Organizations)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_ORGANIZATION_COUNTRY");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("PROJECTS");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Header)
                    .HasMaxLength(10)
                    .HasColumnName("HEADER")
                    .IsFixedLength();

                entity.Property(e => e.LogoPath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LOGO_PATH");

                entity.Property(e => e.OrganizationId).HasColumnName("ORGANIZATION_ID");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROJECTS_ORGANIZATION");
            });

            modelBuilder.Entity<ProjectsOwner>(entity =>
            {
                entity.ToTable("PROJECTS_OWNER");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ProjectsId).HasColumnName("PROJECTS_ID");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Projects)
                    .WithMany(p => p.ProjectsOwners)
                    .HasForeignKey(d => d.ProjectsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROJECTS_OWNER_PROJECTS");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjectsOwners)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROJECTS_OWNER_USER");
            });

            modelBuilder.Entity<ClassBD.Task>(entity =>
            {
                entity.ToTable("TASKS");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CompleteTime)
                    .HasColumnType("datetime")
                    .HasColumnName("COMPLETE_TIME");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_TIME");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Header)
                    .HasMaxLength(10)
                    .HasColumnName("HEADER")
                    .IsFixedLength();

                entity.Property(e => e.MainTaskId).HasColumnName("MAIN_TASK_ID");

                entity.Property(e => e.ProjectsId).HasColumnName("PROJECTS_ID");

                entity.Property(e => e.SubTask).HasColumnName("SUB_TASK");

                entity.Property(e => e.TypeId).HasColumnName("TYPE_ID");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_TIME");

                entity.Property(e => e.UserOwnerId).HasColumnName("USER_OWNER_ID");

                entity.HasOne(d => d.MainTask)
                    .WithMany(p => p.InverseMainTask)
                    .HasForeignKey(d => d.MainTaskId)
                    .HasConstraintName("FK_TASKS_TASKS");

                entity.HasOne(d => d.Projects)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.ProjectsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TASKS_PROJECTS");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TASKS_TYPE_TASKS");
            });

            modelBuilder.Entity<TasksUser>(entity =>
            {
                entity.ToTable("TASKS_USERS");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AccessLevel).HasColumnName("ACCESS_LEVEL");

                entity.Property(e => e.TaskId).HasColumnName("TASK_ID");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TasksUsers)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TASKS_USERS_TASKS");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TasksUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TASKS_USERS_USER");
            });

            modelBuilder.Entity<TimeRecording>(entity =>
            {
                entity.ToTable("TIME_RECORDING");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.TaskId).HasColumnName("TASK_ID");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TimeRecordings)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TIME_RECORDING_TASKS");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TimeRecordings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TIME_RECORDING_USER");
            });

            modelBuilder.Entity<TypeTask>(entity =>
            {
                entity.ToTable("TYPE_TASKS");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .HasColumnName("NAME")
                    .IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AccessLevel)
                    .HasMaxLength(10)
                    .HasColumnName("ACCESS_LEVEL")
                    .IsFixedLength();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AvatarPath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("AVATAR_PATH");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(50)
                    .HasColumnName("DISPLAY_NAME")
                    .IsFixedLength();

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(10)
                    .HasColumnName("EMAIL_ADDRESS")
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .HasColumnName("FIRST_NAME")
                    .IsFixedLength();

                entity.Property(e => e.LastLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("LAST_LOGIN");

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .HasColumnName("LAST_NAME")
                    .IsFixedLength();

                entity.Property(e => e.LoginuserId).HasColumnName("LOGINUSER_ID");

                entity.Property(e => e.TelegramBotId).HasColumnName("TELEGRAM_BOT_ID");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("UPDATED_DATE");

                entity.HasOne(d => d.Loginuser)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.LoginuserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_LOGINUSER");
            });

            modelBuilder.Entity<UserOrganization>(entity =>
            {
                entity.ToTable("USER_ORGANIZATION");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.OrganizationId).HasColumnName("ORGANIZATION_ID");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.UserOrganizations)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_ORGANIZATION_ORGANIZATION");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserOrganizations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_ORGANIZATION_USER");
            });

            modelBuilder.Entity<UserOwner>(entity =>
            {
                entity.ToTable("USER_OWNER");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AccessLevel)
                    .HasMaxLength(10)
                    .HasColumnName("ACCESS_LEVEL")
                    .IsFixedLength();

                entity.Property(e => e.OrganizationId).HasColumnName("ORGANIZATION_ID");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.UserOwners)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_OWNER_ORGANIZATION");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserOwners)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_OWNER_USER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
