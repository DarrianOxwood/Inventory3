using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inventory3.Data;
using Inventory3.Models;

namespace Inventory3.Pages.FixAssets
{
    public class EditModel : PageModel
    {
        private readonly Inventory3.Data.InventoryContext _context;

        public EditModel(Inventory3.Data.InventoryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FixAsset FixAsset { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FixAsset = await _context.FixAssets
                .Include(f => f.Category)
                .Include(f => f.Location).FirstOrDefaultAsync(m => m.ID == id);

            if (FixAsset == null)
            {
                return NotFound();
            }
           ViewData["CategoryID"] = new SelectList(_context.Categorys, "CategoryID", "Title");
           ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "Title");
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

            _context.Attach(FixAsset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FixAssetExists(FixAsset.ID))
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

        private bool FixAssetExists(int id)
        {
            return _context.FixAssets.Any(e => e.ID == id);
        }
    }
}
