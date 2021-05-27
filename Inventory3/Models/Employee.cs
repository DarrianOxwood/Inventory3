using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory3.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Отчество")]
        public string SecondName { get; set; }
        [Display(Name = "Сотрудник")]
        public string FullName
        {
            get { return LastName + " " + FirstName + " " + SecondName; }
        }

        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        public ICollection<Location> Locations { get; set; }
    }
}
