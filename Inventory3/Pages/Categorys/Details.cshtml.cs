using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inventory3.Data;
using Inventory3.Models;
using Microsoft.AspNetCore.Authorization;

namespace Inventory3.Pages.Categorys
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly Inventory3.Data.InventoryContext _context;

        public DetailsModel(Inventory3.Data.InventoryContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Categorys.FirstOrDefaultAsync(m => m.CategoryID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
