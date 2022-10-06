using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using SeedIdentity.Data;

namespace SeedIdentity.Pages_ResolutionPages
{
  public class EditModel : PageModel
  {
    private readonly SeedIdentity.Data.ApplicationDbContext _context;

    public EditModel(SeedIdentity.Data.ApplicationDbContext context)
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
      Resolution = resolution;

      ViewData["Status"] = new SelectList(Enum.GetValues(typeof(Resolution.ResolutionStatus)));
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

      _context.Attach(Resolution).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ResolutionExists(Resolution.ResolutionId))
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

    private bool ResolutionExists(string id)
    {
      return (_context.Resolutions?.Any(e => e.ResolutionId == id)).GetValueOrDefault();
    }
  }
}
