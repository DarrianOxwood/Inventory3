using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory3.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Категория")]
        public string Title { get; set; }

        public ICollection<FixAsset> FixAssets { get; set; }
    }
}
