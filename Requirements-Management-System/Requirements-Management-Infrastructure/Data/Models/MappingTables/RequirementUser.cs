using Requirements_Management_Infrastructure.Data.Models.Requirements;
using System.ComponentModel.DataAnnotations.Schema;

namespace Requirements_Management_Infrastructure.Data.Models.MappingTables
{
    public class RequirementUser
    {
        public int RequirementId { get; set; }

        [ForeignKey(nameof(RequirementId))]
        public Requirement Requirement { get; set; } = null!;

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;
    }
}
