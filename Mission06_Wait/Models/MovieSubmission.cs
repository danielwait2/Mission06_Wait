using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission006Assignment.Models;

public class MovieSubmission
{
    [Key]
    public int MovieId { get; set; } 
    public string Title { get; set; }
    public string? Director { get; set; }
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be greater than or equal to 1888.")]
    public int Year { get; set; }
    public string? Rating { get; set; }
    // null values allowed
    public bool Edited { get; set; }
    public string? LentTo { get; set; }
    public bool CopiedToPlex { get; set; }
    public string? Notes { get; set; }
    // Foreign Key
    [ForeignKey("Categories")]
    public int? CategoryId { get; set; }
    public Categories? Categories { get; set; } // Navigation Property
}
