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
    public class DetailsModel : PageModel
    {
        private readonly SeedIdentity.Data.ApplicationDbContext _context;

        public DetailsModel(SeedIdentity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
