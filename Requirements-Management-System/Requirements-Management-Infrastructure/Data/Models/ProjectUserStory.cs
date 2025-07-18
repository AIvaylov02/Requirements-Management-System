using System.ComponentModel.DataAnnotations.Schema;

namespace Requirements_Management_Infrastructure.Data.Models
{
    public class ProjectUserStory
    {
        public int ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; } = null!;

        public int UserStoryId { get; set; }

        [ForeignKey(nameof(UserStoryId))]
        public UserStory UserStory { get; set; } = null!;
    }
}
