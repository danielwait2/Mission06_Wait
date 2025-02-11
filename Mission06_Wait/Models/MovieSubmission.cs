using System.ComponentModel.DataAnnotations;

namespace Mission006Assignment.Models;

public class MovieSubmission
{
    [Key]
    public int SubmissionID { get; set; }
    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }
    public string Rating { get; set; }
    public bool Edited { get; set; }
    public string LentTo { get; set; }
    public string Notes { get; set; }
}
