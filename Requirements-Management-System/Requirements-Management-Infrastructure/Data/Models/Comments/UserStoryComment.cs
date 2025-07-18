using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Requirements_Management_Infrastructure.Data.Models.Comments
{
    public class UserStoryComment : ADTComment
    {
        // Prior versions?

        [Required]
        public int UserStoryId { get; set; }

        [ForeignKey(nameof(UserStoryId))]
        public UserStory UserStory { get; set; } = null!;

    }
}
