using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NSCCCourseMap.Data;
using NSCCCourseMap.Models;

namespace nscccoursemap_Brennan_Holmes.Pages.Semesters
{
    public class EditModel : PageModel
    {
        private readonly NSCCCourseMap.Data.NSCCCourseMapContext _context;

        public EditModel(NSCCCourseMap.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Semester Semester { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Semesters == null)
            {
                return NotFound();
            }

            var semester =  await _context.Semesters.FirstOrDefaultAsync(m => m.Id == id);
            if (semester == null)
            {
                return NotFound();
            }
            Semester = semester;
           ViewData["AcademicYearId"] = new SelectList(_context.AcademicYears, "Id", "Title");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Semester).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SemesterExists(Semester.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SemesterExists(int id)
        {
          return (_context.Semesters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
