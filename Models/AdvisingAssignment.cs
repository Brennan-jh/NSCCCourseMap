using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Build.Framework;

namespace NSCCCourseMap.Models;

[Index(nameof(InstructorId), nameof(DiplomaYearSectionId), IsUnique = true)]
public class AdvisingAssignment
{
    public int Id { get; set; }

    public int? InstructorId { get; set; }

    public int DiplomaYearSectionId { get; set; }

    // [Display(Name = "Advisor")]
    [Required]
    [ForeignKey("InstructorId")]
    public Instructor? Instructor { get; set; }

    // [Display(Name = "Section")]
    [Required]
    [ForeignKey("DiplomaYearSectionId")]
    public DiplomaYearSection DiplomaYearSection { get; set; } = null!;
}
