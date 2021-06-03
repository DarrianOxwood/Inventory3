using System;
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
    public class IndexModel : PageModel
    {
        private readonly Inventory3.Data.InventoryContext _context;

        public IndexModel(Inventory3.Data.InventoryContext context)
        {
            _context = context;
        }

        public string CurrentFilter { get; set; }
        public string CurrentFilterType { get; set; }
        public IList<FixAsset> FixAssets { get;set; }

        public async Task OnGetAsync(string searchString, string filter)
        {

            CurrentFilter = searchString;
            CurrentFilterType = filter;

            IQueryable<FixAsset> fixAssetsIQ = from s in _context.FixAssets
                                             select s;

            if (!String.IsNullOrEmpty(searchString) &&  filter == "Всему")
            {
                fixAssetsIQ = fixAssetsIQ.Where(s => s.Category.Title.Contains(searchString)
                    || s.Title.Contains(searchString)
                    || s.Location.Title.Contains(searchString)
                    || s.InvNumber.Contains(searchString));


            }

            if (!String.IsNullOrEmpty(searchString) && filter == "Категории")
            {
                fixAssetsIQ = fixAssetsIQ.Where(s => s.Category.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(searchString) && filter == "Названию")
            {
                fixAssetsIQ = fixAssetsIQ.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(searchString) && filter == "Интентарному номеру")
            {
                fixAssetsIQ = fixAssetsIQ.Where(s => s.InvNumber.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(searchString) && filter == "Кабинету")
            {
                fixAssetsIQ = fixAssetsIQ.Where(s => s.Location.Title.Contains(searchString));
            }

            FixAssets = await fixAssetsIQ
                .Include(f => f.Category)
                .Include(f => f.Location).ToListAsync();
        }
    }
}
