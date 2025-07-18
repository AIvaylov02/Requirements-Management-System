using Requirements_Management_Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Requirements_Management_Infrastructure.Data.Models.Requirements
{
    public class RequirementsDependancy
    {
        public int FirstRequirementId { get; set; }

        [ForeignKey(nameof(FirstRequirementId))]
        public Requirement FirstRequirement { get; set; } = null!;

        public int SecondRequirementId { get; set; }

        [ForeignKey(nameof(SecondRequirementId))]
        public Requirement SecondRequirement { get; set; } = null!;

        [Required]
        public RequirementsDependancyScale DependancyLevel { get; set; }
    }
}
