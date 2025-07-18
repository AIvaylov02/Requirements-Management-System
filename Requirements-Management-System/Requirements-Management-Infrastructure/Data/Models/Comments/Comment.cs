using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Requirements_Management_Infrastructure.Data.DataConstraints;

namespace Requirements_Management_Infrastructure.Data.Models.Comments
{
    // All Comments share this inferface (abstract class since EF works only with those). Since they only differ in what mapping table is used onto them, then we should extend it with CommentClasses
    // Which will generate N extension tables for the N comment subentities - they would contain only the additional information. The method is called Table per type
    // Another option would be to use Table per Hiearchy, but that would create a E/R model, where a giant table would have a lot of nullable columns

    // To set up TPT we would use Fluent API

    public abstract class Comment
    {
        [Key]
        public int Id { get ; set ; }
        public DateTime CreationDate { get; set; }
        
        [MaxLength(TITLE_MAX_LENGTH)]
        public string? Title { get; set; }

        [Required]
        public string Content { get; set; } = null!;

        [Required]
        public int AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public User Author { get; set; } = null!;
    }
}
