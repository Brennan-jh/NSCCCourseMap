using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;

namespace nscccoursemap_Brennan_Holmes.Pages.AdvisingAssignments
{
    public class IndexModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public IndexModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<AdvisingAssignment> AdvisingAssignment { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AdvisingAssignments != null)
            {
                AdvisingAssignment = await _context.AdvisingAssignments
                    .Include(a => a.DiplomaYearSection)
                    .Include(a => a.Instructor)
                    .Include(a => a.DiplomaYearSection.DiplomaYear)
                    .Include(a => a.DiplomaYearSection.DiplomaYear.Diploma)
                    .OrderBy(a => a.DiplomaYearSection.DiplomaYear.Diploma.Title)
                    .ThenBy(a => a.DiplomaYearSection.DiplomaYear.Title)
                    .ThenBy(a => a.DiplomaYearSection.Title)
                    .ToListAsync();
            }
        }
    }
}
