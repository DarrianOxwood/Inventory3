using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inventory3.Data;
using Inventory3.Models;

namespace Inventory3.Pages.Categorys
{
    public class IndexModel : PageModel
    {
        private readonly Inventory3.Data.InventoryContext _context;

        public IndexModel(Inventory3.Data.InventoryContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Categorys.ToListAsync();
        }
    }
}
