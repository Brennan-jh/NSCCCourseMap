using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;

namespace nscccoursemap_Brennan_Holmes.Pages.CoursePrerequisites
{
    public class DetailsModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public DetailsModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

      public CoursePrerequisite CoursePrerequisite { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CoursePrerequisites == null)
            {
                return NotFound();
            }

            var courseprerequisite = await _context.CoursePrerequisites
            // .Include(cp => cp.Courses.Title)
            // .Include(cp => cp.Prerequisites.Title)
            // .Include(cp => cp.Courses.CourseCode)
            .Include(cp => cp.Courses)
            .Include(cp => cp.Prerequisites)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (courseprerequisite == null)
            {
                return NotFound();
            }
            else
            {
                CoursePrerequisite = courseprerequisite;
            }
            return Page();
        }
    }
}
