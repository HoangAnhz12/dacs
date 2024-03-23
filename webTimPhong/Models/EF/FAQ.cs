using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webTimPhong.Models.EF
{
    [Table("FAQ")]
    public class FAQ 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Họ và Tên")]
        public string HoTen { get; set; }
        [Display(Name = "Số điện thoại")]
        public int Phone { get; set; }
        [EmailAddress]
        [Required]
        [Display(Name = "Nhập Email")]
        public string Email { get; set; }
        [AllowHtml]
        [Display(Name = "Yêu cầu")]
        public string Question { get; set; }
    }
}