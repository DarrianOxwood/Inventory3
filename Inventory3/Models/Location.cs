using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Inventory3.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        [StringLength(50)]
        [Display(Name = "Кабинет")]
        public string Title { get; set; }
        [Display(Name = "Сотрудник")]
        public int? EmployeeID { get; set; }
        public Employee Employee { get; set; }

        public ICollection<FixAsset> FixAssets { get; set; }
    }
}
