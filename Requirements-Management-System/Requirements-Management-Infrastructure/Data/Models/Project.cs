using Requirements_Management_Infrastructure.Data.Models.Comments;
using System.ComponentModel.DataAnnotations;
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

        // Owner - User - FK

        // Participants - User[]

        // IRequirements[]

        // UserStories[] - no! it is a many to many, since a user story can be reused within many projects. Optional detaching

        public ICollection<ProjectComment> Comments { get; set; } = new List<ProjectComment>();

        // Prior versions?
    }
}
