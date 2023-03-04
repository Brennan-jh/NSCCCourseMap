using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NSCCCourseMap.Models;

[Index(nameof(Title), nameof(DiplomaId), IsUnique = true)]
public class DiplomaYear
{
    public int Id { get; set; }

    [Required]
    [RegularExpression(@"^(Year ) [1,4]$")]
    public string? Title { get; set; }

    [Required]
    [Display(Name = "Diploma")]
    public int DiplomaId { get; set; }

    //Computed Property
    public string FullDiploma
    {
        get { return Diploma.Title + " - " + Title; }
    }

    // Naviation properties
    [ForeignKey("DiplomaId")]
    public Diploma Diploma { get; set; } = default!;

    public ICollection<DiplomaYearSection>? DiplomaYearSections { get; set; } = null!;
}
