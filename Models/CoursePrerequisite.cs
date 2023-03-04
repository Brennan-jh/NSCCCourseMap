using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Build.Framework;

namespace NSCCCourseMap.Models;

[Index(nameof(CourseId), nameof(PrerequisiteId),
    IsUnique = true)]
public class CoursePrerequisite {
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int PrerequisiteId { get; set; }

    [Required]
    [ForeignKey("CourseId")]
    public Course Courses { get; set; } = null!;

    [Required]
    [ForeignKey("PrerequisiteId")]
    public Course Prerequisites { get; set; } = null!;
}