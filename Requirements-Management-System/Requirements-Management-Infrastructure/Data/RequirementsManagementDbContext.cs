using Microsoft.EntityFrameworkCore;
using Requirements_Management_Infrastructure.Data.Models;
using Requirements_Management_Infrastructure.Data.Models.Comments;
using Requirements_Management_Infrastructure.Data.Models.MappingTables;
using Requirements_Management_Infrastructure.Data.Models.Requirements;

namespace Requirements_Management_Infrastructure.Data
{
    public class RequirementsManagementDbContext : DbContext
    {
        public RequirementsManagementDbContext() : base()
        { 
        }

        public RequirementsManagementDbContext(DbContextOptions<RequirementsManagementDbContext> options) : base(options)
        {
        }

        #region BaseEntities
        public DbSet<Project> Projects { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserStory> UserStories { get; set; }

        #region Comments
        public DbSet<Comment> Comments { get; set; } // EF Core doesn't understand interfaces, so we would pass ADT to the the DBSet
        public DbSet<ProjectComment> ProjectsComments { get; set; }

        public DbSet<RequirementComment> RequirementsComments { get; set; }
        public DbSet<UserStoryComment> UserStoriesComments { get; set; }
        #endregion

        #region Requirements
        public DbSet<Requirement> Requirements { get; set; }

        #endregion

        #endregion
        // TODO: ADD HERE THE OTHER TYPES OF REQUIREMENTS
        #region MappingTables
        public DbSet<RequirementsDependancy> RequirementsDependancies { get; set; }

        public DbSet<ProjectRequirement> ProjectsRequirements { get; set; }

        public DbSet<ProjectUser> ProjectsUsers { get; set; }

        public DbSet<ProjectUserStory> ProjectsUserStories { get; set; }

        public DbSet<RequirementUser> RequirementsUsers { get; set; }

        public DbSet<UserStoryRequirement> UserStoriesRequirements { get; set; }

        public DbSet<UserStoryUser> UserStoriesUsers { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            BuildCompositeKeys(modelBuilder);
            MapCommentModelsToTables(modelBuilder);
        }

        private static void BuildCompositeKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequirementsDependancy>().HasKey(rd => new { rd.FirstRequirementId, rd.SecondRequirementId });
            modelBuilder.Entity<ProjectRequirement>().HasKey(pr => new { pr.ProjectId, pr.RequirementId });
            modelBuilder.Entity<ProjectUser>().HasKey(pc => new { pc.ProjectId, pc.UserId });
            modelBuilder.Entity<ProjectUserStory>().HasKey(pus => new { pus.ProjectId, pus.UserStoryId });
            modelBuilder.Entity<RequirementUser>().HasKey(ru => new { ru.RequirementId, ru.UserId });
            modelBuilder.Entity<UserStoryRequirement>().HasKey(usr => new { usr.UserStoryId, usr.RequirementId });
            modelBuilder.Entity<UserStoryUser>().HasKey(usu => new { usu.UserStoryId, usu.UserId });
        }

        private static void MapCommentModelsToTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<ProjectComment>().ToTable("ProjectComments");
            modelBuilder.Entity<UserStoryComment>().ToTable("UserStoryComments");
            modelBuilder.Entity<RequirementComment>().ToTable("RequirementComments");
        }
    }
}
