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
    public class IndexModel : PageModel
    {
        private readonly SeedIdentity.Data.ApplicationDbContext _context;

        public IndexModel(SeedIdentity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Resolution> Resolution { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Resolutions != null)
            {
                Resolution = await _context.Resolutions.ToListAsync();
            }
        }
    }
}
