using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models;

[Index(nameof(Title), nameof(DiplomaYearId), nameof(AcademicYearId), IsUnique = true)]
public class DiplomaYearSection
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Diploma Year")]
    public int DiplomaYearId { get; set; }

    [Required]
    [Display(Name = "Diploma Year Section")]
    public string? Title { get; set; }

    [Required]
    [Display(Name = "Academic Year")]
    public int AcademicYearId { get; set; }

    [Required]
    [RegularExpression(@"^[S] [1,9]$")]
    [ForeignKey("DiplomaYearId")]
    public DiplomaYear DiplomaYear { get; set; } = null!;

    [Required]
    [ForeignKey("AcademicYearId")]
    public AcademicYear AcademicYear { get; set; } = null!;

   public ICollection<CourseOffering> CourseOfferings { get; set; } = null!;
}
