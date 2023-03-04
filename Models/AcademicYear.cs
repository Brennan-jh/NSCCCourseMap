// using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models;

[Index(nameof(Title), nameof(Id), IsUnique = true)]
public class AcademicYear {
    public int Id { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 5)]
    public string Title { get; set; } = null!;

    public ICollection<Semester>? Semesters { get; set; } = null!;
    public ICollection<DiplomaYearSection>? DiplomaYearSections { get; set; } = null!;
}