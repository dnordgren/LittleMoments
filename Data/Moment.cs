using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace LittleMoments.Data;

public class Moment
{
    [Key]
    public required string Id { get; set; }

    [Required]
    public DateTime MomentTimestamp { get; set; }

    [Required]
    public required string CareGiverId { get; set; }

    [Required]
    public required string BabyId { get; set; }

    [Required]
    public MomentActivityType MomentActivityType { get; set; }

    [Required]
    public required string MomentActivity { get; set; } // Store the serialized protobuf data

    public string? Location { get; set; }

    public string? BabyMood { get; set; }

    public List<string>? Tags { get; set; } // EF Core will store this as a JSON string

    public string? MomentMemo { get; set; }

    public string? RelatedMomentId { get; set; }

    [ForeignKey("CareGiverId")]
    public IdentityUser? CareGiver { get; set; }

    [ForeignKey("BabyId")]
    public Baby? Baby { get; set; }

    [ForeignKey("RelatedMomentId")]
    public Moment? RelatedMoment { get; set; }
}
