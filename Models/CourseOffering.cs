using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
// using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace NSCCCourseMap.Models;

[Index(nameof(CourseId), nameof(InstructorId),
    nameof(DiplomaYearSectionId),
    nameof(SemesterId),
    IsUnique = true)]
public class CourseOffering {
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int? InstructorId { get; set; }

    public int DiplomaYearSectionId { get; set; }

    public int SemesterId { get; set; }

    [Display(Name = "Is Directed Elective")]
    public bool IsDirectedElective { get; set; } = false;

    [Required]
    [ForeignKey("CourseId")]
    public Course? Course { get; set; } = null!;

    [ForeignKey("InstructorId")]
    public Instructor? Instructor { get; set; }

    [Required]
    [Display(Name = "Diploma Year Section")]
    [ForeignKey("DiplomaYearSectionId")]
    public DiplomaYearSection? DiplomaYearSection { get; set; }

    [Required]
    [ForeignKey("SemesterId")]
    public Semester? Semester { get; set; }
}