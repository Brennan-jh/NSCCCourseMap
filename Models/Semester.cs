// using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models;

[Index(nameof(Name), nameof(StartDate), nameof(EndDate), nameof(AcademicYearId), IsUnique = true)]
public class Semester
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required(ErrorMessage = "EndDate must be later than the StartDate.")]
    [Display(Name = "Start Date")]
    [DataType(DataType.Date)]
    [DisplayFormatAttribute(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "StartDate must be later than the EndDate.")]
    [Display(Name = "End Date")]
    [DataType(DataType.Date)]
    [DisplayFormatAttribute(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
    public DateTime EndDate { get; set; }

    // Citation for code:
    // https://learn.microsoft.com/en-us/answers/questions/1146829/asp-net-core-web-api-datetime-data-annotations-com

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (EndDate <= StartDate)
        {
            yield return new ValidationResult(
                "End date must be greater than the start date.",
                new[] { "EndDate" }
            );
        }
    }

    public int AcademicYearId { get; set; }

    [Display(Name = "Academic Year")]
    [ForeignKey("AcademicYearId")]
    public AcademicYear AcademicYear { get; set; } = null!;

    public ICollection<CourseOffering>? CourseOfferings { get; set; } = null!;
}
