using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inventory3.Data;
using Inventory3.Models;
using Inventory3.Models.InventoryViewModels;

namespace Inventory3.Pages.Locations
{
    public class IndexModel : PageModel
    {
        private readonly Inventory3.Data.InventoryContext _context;

        public IndexModel(Inventory3.Data.InventoryContext context)
        {
            _context = context;
        }

        public EmployeeIndexData EmployeeData { get; set; }
        public int EmployeeID { get; set; }
        public int LocationID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            EmployeeData = new EmployeeIndexData();
            EmployeeData.Locations = await _context.Locations
                .Include(l => l.Employee)
                .ToListAsync();


            if (id != null)
            {
                LocationID = id.Value;
                var selectedLocation = EmployeeData.Locations
                    .Where(x => x.LocationID == id).Single();
                await _context.Entry(selectedLocation)
                              .Collection(x => x.FixAssets).LoadAsync();
                foreach (FixAsset fixAsset in selectedLocation.FixAssets)
                {
                    await _context.Entry(fixAsset).Reference(x => x.Category).LoadAsync();
                }
                EmployeeData.FixAssets = selectedLocation.FixAssets;
            }

        }
    }
}
