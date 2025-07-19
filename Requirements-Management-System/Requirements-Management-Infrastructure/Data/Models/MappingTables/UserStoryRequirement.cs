using Requirements_Management_Infrastructure.Data.Models.Requirements;
using System.ComponentModel.DataAnnotations.Schema;

namespace Requirements_Management_Infrastructure.Data.Models.MappingTables
{
    public class UserStoryRequirement
    {
        public int UserStoryId { get; set; }

        [ForeignKey(nameof(UserStoryId))]
        public UserStory UserStory { get; set; } = null!;

        public int RequirementId { get; set; }

        [ForeignKey(nameof(RequirementId))]
        public Requirement Requirement { get; set; } = null!;
    }
}
