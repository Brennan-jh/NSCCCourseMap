using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models;

[Index(nameof(Title), IsUnique = true)]
public class Diploma {
    public int Id { get; set; }

    [Required]
    [MinLength(10)]
    public string? Title { get; set; }

    // Navigation Properties
    public ICollection<DiplomaYear>? DiplomasYears { get; set; } = null!;
}