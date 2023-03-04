// using Microsoft.Build.Framework;

using System.ComponentModel.DataAnnotations;

namespace NSCCCourseMap.Models;

public class Instructor
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    [Display(Name = "First Name")]
    [Required]
    public string? FirstName { get; set; }

    //Computed Property
    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }

    public ICollection<CourseOffering>? CourseOfferings { get; set; } = null!;

    public ICollection<AdvisingAssignment>? AdvisingAssignments { get; set; } = null!;
}
