﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inventory3.Data;
using Inventory3.Models;

namespace Inventory3.Pages.FixAssets
{
    public class DeleteModel : PageModel
    {
        private readonly Inventory3.Data.InventoryContext _context;

        public DeleteModel(Inventory3.Data.InventoryContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FixAsset = await _context.FixAssets.FindAsync(id);

            if (FixAsset != null)
            {
                _context.FixAssets.Remove(FixAsset);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
