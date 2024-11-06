using System.ComponentModel.DataAnnotations;

namespace LittleMoments.Data
{
    public class Baby
    {
        [Key]
        public required string Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required DateTime Birthday { get; set; }
    }
}
