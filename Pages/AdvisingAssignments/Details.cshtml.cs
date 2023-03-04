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
    public class DetailsModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public DetailsModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

      public AdvisingAssignment AdvisingAssignment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AdvisingAssignments == null)
            {
                return NotFound();
            }

            var advisingassignment = await _context.AdvisingAssignments
            .Include(a => a.Instructor)
            .Include(a => a.DiplomaYearSection)
            .Include(a => a.DiplomaYearSection.DiplomaYear.Diploma)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (advisingassignment == null)
            {
                return NotFound();
            }
            else
            {
                AdvisingAssignment = advisingassignment;
            }
            return Page();
        }
    }
}
