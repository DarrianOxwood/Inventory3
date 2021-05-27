using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory3.Models.InventoryViewModels
{
    public class EmployeeIndexData
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<FixAsset> FixAssets { get; set; }
    }
}
