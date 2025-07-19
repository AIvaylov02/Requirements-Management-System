using Requirements_Management_Infrastructure.Data.Models.Comments;
using Requirements_Management_Infrastructure.Data.Models.MappingTables;
using System.ComponentModel.DataAnnotations;
using static Requirements_Management_Infrastructure.Data.DataConstraints;

namespace Requirements_Management_Infrastructure.Data.Models
{
    public class User // TODO : be Extension of Identity
    {
        [Required]
        [MaxLength(USER_NAME_LENGTH)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(USER_NAME_LENGTH)]
        public string LastName { get; set; } = null!;

        public ICollection<Project> OwnedProjects { get; set; } = new List<Project>();

        public ICollection<ProjectUser> ContributesToProjects { get; set; } = new List<ProjectUser>();

        public ICollection<ProjectComment> CommentsUnderProjects { get; set; } = new List<ProjectComment>();


        public ICollection<UserStoryUser> UserUserStories { get; set; } = new List<UserStoryUser>();
        public ICollection<UserStoryComment> CommentsUnderUserStories { get; set; } = new List<UserStoryComment>();


        public ICollection<RequirementUser> UserRequirements { get; set; } = new List<RequirementUser>();
        public ICollection<RequirementComment> CommentsUnderRequirements { get; set; } = new List<RequirementComment>();
    }
}
