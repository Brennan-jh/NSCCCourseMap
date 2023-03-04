using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;

namespace nscccoursemap_Brennan_Holmes.Pages.DiplomaYears
{
    public class DetailsModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public DetailsModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

      public DiplomaYear DiplomaYear { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DiplomaYears == null)
            {
                return NotFound();
            }

            var diplomayear = await _context.DiplomaYears
            .Include(dy => dy.DiplomaYearSections)
            .ThenInclude(dy => dy.CourseOfferings.OrderByDescending(dy => dy.Semester))
            .ThenInclude(dy => dy.Semester)
            .OrderBy(dy => dy.Diploma)
            .Include(dy => dy.DiplomaYearSections)
            .ThenInclude(dy => dy.CourseOfferings)
            .ThenInclude(dy => dy.Course)
            .Include(dy => dy.DiplomaYearSections)
            .ThenInclude(dy => dy.CourseOfferings)
            .ThenInclude(dy => dy.Instructor)
            .ThenInclude(dy => dy.AdvisingAssignments)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (diplomayear == null)
            {
                return NotFound();
            }
            else
            {
                DiplomaYear = diplomayear;
            }
            return Page();
        }
    }
}
