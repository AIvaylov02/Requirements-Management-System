using Requirements_Management_Infrastructure.Data.Models.Requirements;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Requirements_Management_Infrastructure.Data.Models.Comments
{
    public class RequirementComment : Comment
    {
        // Prior versions?

        [Required]
        public int RequirementId { get; set; }

        [ForeignKey(nameof(RequirementId))]
        public Requirement Requirement { get; set; } = null!;
    }
}
