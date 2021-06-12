using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Inventory3.Data;
using Inventory3.Models;
using Microsoft.AspNetCore.Authorization;

namespace Inventory3.Pages.FixAssets
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly Inventory3.Data.InventoryContext _context;

        public CreateModel(Inventory3.Data.InventoryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryID"] = new SelectList(_context.Categorys, "CategoryID", "Title");
        ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "Title");
            return Page();
        }

        [BindProperty]
        public FixAsset FixAsset { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FixAssets.Add(FixAsset);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
