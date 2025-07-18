using System.ComponentModel.DataAnnotations.Schema;

namespace Requirements_Management_Infrastructure.Data.Models
{
    public class ProjectUser
    {
        public int ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
