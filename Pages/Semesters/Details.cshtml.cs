using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;

namespace nscccoursemap_Brennan_Holmes.Pages.Semesters
{
    public class DetailsModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public DetailsModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

      public Semester Semester { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Semesters == null)
            {
                return NotFound();
            }

            var semester = await _context.Semesters
            .Include(i => i.CourseOfferings)
            .ThenInclude(i => i.Instructor)
            .Include(i => i.CourseOfferings)
            .ThenInclude(i => i.Course)
            .Include(i => i.CourseOfferings)
            .ThenInclude(i => i.DiplomaYearSection)
            .ThenInclude(i => i.DiplomaYear)
            .ThenInclude(i => i.Diploma)
            .Include(i => i.AcademicYear)
            .Include(s => s.CourseOfferings
                    .OrderBy(cof => cof.Course.CourseCode)
                        .OrderBy(cof => cof.DiplomaYearSection.DiplomaYear!.Title)
                            .OrderBy(cof => cof.DiplomaYearSection.DiplomaYear.Diploma!.Title)
                    )!
            .FirstOrDefaultAsync(m => m.Id == id);
            if (semester == null)
            {
                return NotFound();
            }
            else
            {
                Semester = semester;
            }
            return Page();
        }
    }
}
