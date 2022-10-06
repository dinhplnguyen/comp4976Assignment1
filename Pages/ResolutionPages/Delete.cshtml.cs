using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;
using SeedIdentity.Data;

namespace SeedIdentity.Pages_ResolutionPages
{
    public class DeleteModel : PageModel
    {
        private readonly SeedIdentity.Data.ApplicationDbContext _context;

        public DeleteModel(SeedIdentity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Resolution Resolution { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Resolutions == null)
            {
                return NotFound();
            }

            var resolution = await _context.Resolutions.FirstOrDefaultAsync(m => m.ResolutionId == id);

            if (resolution == null)
            {
                return NotFound();
            }
            else 
            {
                Resolution = resolution;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Resolutions == null)
            {
                return NotFound();
            }
            var resolution = await _context.Resolutions.FindAsync(id);

            if (resolution != null)
            {
                Resolution = resolution;
                _context.Resolutions.Remove(Resolution);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
