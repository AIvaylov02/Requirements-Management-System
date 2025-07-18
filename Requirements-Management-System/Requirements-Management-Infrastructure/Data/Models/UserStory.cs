using Requirements_Management_Infrastructure.Data.Models.Comments;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Requirements_Management_Infrastructure.Data.DataConstraints;

namespace Requirements_Management_Infrastructure.Data.Models
{
    public class UserStory
    {
        public int Id { get; set; }

        [MaxLength(TITLE_MAX_LENGTH)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(USERSTORY_PERSONA_MAX_LENGTH)]
        public string Persona { get; set; } = null!;

        [Required]
        [MaxLength(USERSTORY_WISH_REASON_MAX_LENGTH)] // usually over 100 is a signal for bad design of the story, but I should not limit the users of the system
        public string Wish { get; set; } = null!;

        [Required]
        [MaxLength(USERSTORY_WISH_REASON_MAX_LENGTH)]
        public string Reason { get; set; } = null!;

        [Required]
        public int AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public User Author { get; set; } = null!;


        // NB - it is not of an interface, since we use TPT - we can go concrete here
        public ICollection<UserStoryComment> Comments { get; set; } = new List<UserStoryComment>();

        // User story can be mapped to many projects - Mapping table between projects and user stories (then detach is possible)

        public ICollection<UserStoryRequirement> UserStoryRequirements { get; set; } = new List<UserStoryRequirement>();

        public ICollection<ProjectUserStory> UserStoryProjects { get; set; } = new List<ProjectUserStory>();
    }
}
