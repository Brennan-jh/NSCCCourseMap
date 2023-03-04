using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;

namespace nscccoursemap_Brennan_Holmes.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public DetailsModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public Course Course { get; set; } = default!;

//         public async Task<IActionResult> OnGetAsync(int? id)
//         {
//             if (id == null || _context.Courses == null)
//             {
//                 return NotFound();
//             }

//             var course = await _context.Courses
//                 .Include(c => c.Prerequisites)
//                 .ThenInclude(cpr => cpr.Prerequisites)
//                 .Include(c => c.IsPrerequisiteFor)
//                 .FirstOrDefaultAsync(m => m.Id == id);
//             // var course = await _context.Courses
//             // .Include(c => c.Prerequisites)
//             // .ThenInclude(cpr => cpr.Prerequisites)
//             // .Include(c => c.IsPrerequisiteFor)
//             // .ThenInclude(cpr => cpr.Courses)
//             // .FirstOrDefaultAsync(m => m.Id == id);
//             if (course == null)
//             {
//                 return NotFound();
//             }
//             else
//             {
//                 Course = course;
//             }
//             return Page();
//         }
//     }
// }
 public async Task<IActionResult> OnGetAsync(int? id)
        {
            List<Course> Prerequisites = null!;

            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Prerequisites)
                .ThenInclude(cpr => cpr.Prerequisites)
                .Include(c => c.IsPrerequisiteFor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            else
            {
                Course = course;
                if (course.Prerequisites != null)
                {
                    Prerequisites = course.Prerequisites.Select(cpr => cpr.Prerequisites).ToList();
                }
            }
            return Page();
        }
    }
}
