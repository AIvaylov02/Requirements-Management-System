using Requirements_Management_Infrastructure.Data.Models.Enums;
using Requirements_Management_Infrastructure.Data.Models.Requirements;
using System.ComponentModel.DataAnnotations.Schema;

namespace Requirements_Management_Infrastructure.Data.Models.MappingTables
{
    public class ProjectRequirement
    {
        public int ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; } = null!;

        public int RequirementId { get; set; }

        [ForeignKey(nameof(RequirementId))]
        public Requirement Requirement { get; set; } = null!;

        public Priority Priority { get; set; }
    }
}
