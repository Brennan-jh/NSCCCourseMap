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
    public class IndexModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public IndexModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<CourseOffering> CourseOffering { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CourseOfferings != null)
            {
                CourseOffering = await _context.CourseOfferings
                .Include(co => co.Course)
                .Include(co => co.DiplomaYearSection)
                .Include(co => co.DiplomaYearSection.DiplomaYear)
                .Include(co=> co.DiplomaYearSection.DiplomaYear.Diploma)
                .Include(co => co.Instructor)
                .Include(co => co.Semester)
                .OrderByDescending(s => s.Semester)
                .ThenBy(cof => cof.DiplomaYearSection.DiplomaYear.Diploma)
                .ThenBy(cof => cof.DiplomaYearSection.DiplomaYear)
                .ThenBy(cof => cof.Course.CourseCode)
                .Include(cof => cof.Semester)
                .ToListAsync();
            }
        }
    }
}
