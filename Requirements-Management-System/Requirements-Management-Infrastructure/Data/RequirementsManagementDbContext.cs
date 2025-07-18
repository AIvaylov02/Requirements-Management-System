using Microsoft.EntityFrameworkCore;
using Requirements_Management_Infrastructure.Data.Models;
using Requirements_Management_Infrastructure.Data.Models.Comments;

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

        public DbSet<ADTComment> Comments { get; set; } // EF Core doesn't understand interfaces, so we would pass ADT to the the DBSet
        public DbSet<ProjectComment> ProjectComments { get; set; }
        public DbSet<UserStoryComment> UserStoryComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            MapCommentModelsToTables(modelBuilder);


        }

        private static void MapCommentModelsToTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADTComment>().ToTable("Comments");
            modelBuilder.Entity<ProjectComment>().ToTable("ProjectComments");
            modelBuilder.Entity<UserStoryComment>().ToTable("UserStoryComments");
            // RequirementsComment
        }
    }
}
