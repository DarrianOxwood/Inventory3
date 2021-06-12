using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inventory3.Data;
using Inventory3.Models;
using System.Drawing;
using System.IO;
using QRCoder;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Authorization;

namespace Inventory3.Pages.FixAssets
{
    [Authorize]
    public class DetailsModel : PageModel
    {


        private readonly Inventory3.Data.InventoryContext _context;

        public DetailsModel(Inventory3.Data.InventoryContext context)
        {
            _context = context;
        }

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
    }
}
