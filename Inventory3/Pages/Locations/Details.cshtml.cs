using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inventory3.Data;
using Inventory3.Models;

namespace Inventory3.Pages.Locations
{
    public class DetailsModel : PageModel
    {
        private readonly Inventory3.Data.InventoryContext _context;

        public DetailsModel(Inventory3.Data.InventoryContext context)
        {
            _context = context;
        }

        public Location Location { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Location = await _context.Locations
                .Include(l => l.Employee)
                .Include(i => i.Employee.Department)
                .FirstOrDefaultAsync(m => m.LocationID == id);

            if (Location == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
