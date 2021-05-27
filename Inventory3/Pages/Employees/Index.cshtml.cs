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

namespace Inventory3.Pages.Employees
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


        public async Task OnGetAsync(int? id, int? locationID)
        {
            EmployeeData = new EmployeeIndexData();
            EmployeeData.Employees = await _context.Employees
                .Include(i => i.Department)
                .Include(i => i.Locations)
                .OrderBy(i => i.LastName)
                .ToListAsync();

            if(id != null)
            {
                EmployeeID = id.Value;
                Employee employee = EmployeeData.Employees
                    .Where(i => i.EmployeeID == id.Value).Single();
                EmployeeData.Locations = employee.Locations;
            }

            if (locationID != null)
            {
                LocationID = locationID.Value;
                var selectedLocation = EmployeeData.Locations
                    .Where(x => x.LocationID == locationID).Single();
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
