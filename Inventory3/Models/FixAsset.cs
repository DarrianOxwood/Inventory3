using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QRCoder;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Inventory3.Models
{

    public class FixAsset
    {
        //private static byte[] qrCodeAsPngByteArr()
        //{
        //    QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //    QRCodeData qrCodeData = qrGenerator.CreateQrCode("The text which should be encoded.", QRCodeGenerator.ECCLevel.Q);
        //    PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
        //    byte[] qrCodeAsPngByteArr = qrCode.GetGraphic(20);
        //    return qrCodeAsPngByteArr;
        //}
        private static Bitmap qrCodeAsBitmap()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("The payload aka the text which should be encoded.", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            qrCodeImage.Save("wwwroot/QRcode.jpg", ImageFormat.Jpeg);

            return qrCodeImage;
        }


        public int ID { get; set; }
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
        public int LocationID { get; set; }
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

        public Bitmap QRcode = qrCodeAsBitmap();
        public Category Category { get; set; }
        public Location Location { get; set; }




       
    }
}
