using Microsoft.EntityFrameworkCore;
using Requirements_Management_Infrastructure.Data.Models;
using Requirements_Management_Infrastructure.Data.Models.Comments;
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

        public DbSet<Project> Projects { get; set; }

        public DbSet<UserStory> UserStories { get; set; }

        public DbSet<Comment> Comments { get; set; } // EF Core doesn't understand interfaces, so we would pass ADT to the the DBSet
        public DbSet<ProjectComment> ProjectComments { get; set; }
        public DbSet<UserStoryComment> UserStoriesComments { get; set; }

        public DbSet<UserStoryRequirement> UserStoriesRequirements { get; set; }

        public DbSet<RequirementsDependancy> RequirementsDependancies { get; set; }

        public DbSet<ProjectRequirement> ProjectsRequirements { get; set; }

        public DbSet<ProjectUserStory> ProjectsUserStories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProjectUser>().HasKey(pc => new { pc.ProjectId, pc.UserId });
            modelBuilder.Entity<UserStoryRequirement>().HasKey(usr => new {usr.UserStoryId, usr.RequirementId });
            modelBuilder.Entity<RequirementsDependancy>().HasKey(rd => new {rd.FirstRequirementId, rd.SecondRequirementId});
            modelBuilder.Entity<ProjectRequirement>().HasKey(pr => new { pr.ProjectId, pr.RequirementId });
            modelBuilder.Entity<ProjectUserStory>().HasKey(pus => new { pus.ProjectId, pus.UserStoryId });

            MapCommentModelsToTables(modelBuilder);


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
