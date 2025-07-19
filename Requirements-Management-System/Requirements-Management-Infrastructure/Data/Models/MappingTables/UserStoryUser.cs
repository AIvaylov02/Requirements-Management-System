using System.ComponentModel.DataAnnotations.Schema;

namespace Requirements_Management_Infrastructure.Data.Models.MappingTables
{
    public class UserStoryUser
    {
        public int UserStoryId { get; set; }

        [ForeignKey(nameof(UserStoryId))]
        public UserStory UserStory { get; set; } = null!;

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;
    }
}
