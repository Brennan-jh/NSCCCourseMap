using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models;

[Index(nameof(CourseCode), IsUnique = true)]
public class Course
{
    public int Id { get; set; }

    [Display(Name = "Course Code")]
    [Required]
    [RegularExpression(
        @"^[A-Z]{1,4}\s[0-9]{4}$",
        ErrorMessage = "Course Code must take a valid expression."
    )]
    [StringLength(100, MinimumLength = 5)]
    public string? CourseCode { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 5)]
    public string? Title { get; set; }

    // Navigation Properties
    public ICollection<CoursePrerequisite>? Prerequisites { get; set; }
    public ICollection<CoursePrerequisite>? IsPrerequisiteFor { get; set; }
    public ICollection<CourseOffering>? CourseOfferings { get; set; }
}
