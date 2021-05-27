using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory3.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        [Required]
        [Display(Name = "Кафедра")]
        public string Title { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
