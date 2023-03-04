using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;

namespace nscccoursemap_Brennan_Holmes.Pages.CourseOfferings
{
    public class DetailsModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public DetailsModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

      public CourseOffering CourseOffering { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CourseOfferings == null)
            {
                return NotFound();
            }

            var courseoffering = await _context.CourseOfferings
            .Include(c => c.Course)
            .Include(c => c.Instructor)
            .Include(c => c.DiplomaYearSection)
            .ThenInclude(c => c.DiplomaYear.Diploma)
            .Include(c => c.Semester)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (courseoffering == null)
            {
                return NotFound();
            }
            else
            {
                CourseOffering = courseoffering;
            }
            return Page();
        }
    }
}
