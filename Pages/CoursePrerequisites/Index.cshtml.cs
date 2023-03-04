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
    public class IndexModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public IndexModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<CoursePrerequisite> CoursePrerequisite { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CoursePrerequisites != null)
            {
                CoursePrerequisite = await _context.CoursePrerequisites
                .Include(c => c.Courses)
                .Include(c => c.Prerequisites)
                .OrderBy(cp => cp.Courses.CourseCode)
                .ThenBy(cp => cp.Prerequisites.CourseCode)
                .ToListAsync();
            }
        }
    }
}
