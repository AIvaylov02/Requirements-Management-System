using Requirements_Management_Infrastructure.Data.Models.Comments;
using Requirements_Management_Infrastructure.Data.Models.MappingTables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Requirements_Management_Infrastructure.Data.DataConstraints;

namespace Requirements_Management_Infrastructure.Data.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(PROJECT_TITLE_MAX_LENGTH)]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public string? PathToImage { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public User Owner { get; set; } = null!;

        public ICollection<ProjectUser> Participants { get; set; } = new List<ProjectUser>();

        // Many to many, since a project intakes multiple requirements and a requirement could be shared among projects
        public ICollection<ProjectRequirement> ProjectRequirements { get; set; } = new List<ProjectRequirement>();

        // UserStories[] - no! it is a many to many, since a user story can be reused within many projects. Optional detaching
        public ICollection<ProjectUserStory> ProjectUserStories { get; set; } = new List<ProjectUserStory>();

        public ICollection<ProjectComment> Comments { get; set; } = new List<ProjectComment>();

        // Prior versions?
    }
}
