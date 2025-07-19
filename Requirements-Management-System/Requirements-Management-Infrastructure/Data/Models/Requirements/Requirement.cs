using Requirements_Management_Infrastructure.Data.Models.Comments;
using Requirements_Management_Infrastructure.Data.Models.MappingTables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Requirements_Management_Infrastructure.Data.DataConstraints;

namespace Requirements_Management_Infrastructure.Data.Models.Requirements
{
    public abstract class Requirement
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(TITLE_MAX_LENGTH)]
        public string? Title { get; set; }

        [Required]
        public string Description { get; set; } = null!;

        // Since a requirement can be written by multiple people, the relationship should be many-many
        public ICollection<RequirementUser> RequirementAuthors { get; set; } = new List<RequirementUser>();

        public ICollection<RequirementComment> Comments { get; set; } = new List<RequirementComment>();

        // User stories - many to many, since a story can generate multiple requirements and requirements can be built upon many stories
        public ICollection<UserStoryRequirement> RequirementUserStories { get; set; } = new List<UserStoryRequirement>();

        // A requirement has N requirements, which depend on it and can influence N others - each dependency has an impactCoefficient
        public ICollection<RequirementsDependancy> RelationToOtherRequirements { get; set; } = new List<RequirementsDependancy>();
        
        public int? ParentRequirementId { get; set; }
        
        [ForeignKey(nameof(ParentRequirementId))]
        [InverseProperty(nameof(SubRequirements))] // We have to use inverse property (how to get back to this location using the property on the other entity), since we have many Requirements FKs in the class
        public Requirement? ParentRequirement { get; set; }

        [InverseProperty(nameof(ParentRequirement))]
        public ICollection<Requirement> SubRequirements { get; set; } = new List<Requirement>();

        public ICollection<ProjectRequirement> RequirementProjects { get; set; } = new List<ProjectRequirement>();
    }
}
