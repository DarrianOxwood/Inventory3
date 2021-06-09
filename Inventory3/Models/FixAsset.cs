using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;


namespace Inventory3.Models
{

    public class FixAsset
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Категория")]
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Инвентаный номер")]
        public string InvNumber { get; set; }
        [Display(Name = "Код справочника")]
        public string RefCode { get; set; }
        [Display(Name = "Кабинет")]
        public int? LocationID { get; set; }
        [Required]
        [Display(Name = "Количество")]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Цена")]
        public double Price { get; set; }
        [Display(Name = "Сумма")]
        public double Summ
        {
            get { return Price * Convert.ToDouble(Quantity); }
        }
        [Display(Name = "Описание")]
        public string Discription { get; set; }
        public Category Category { get; set; }
        public Location Location { get; set; }




       
    }
}
