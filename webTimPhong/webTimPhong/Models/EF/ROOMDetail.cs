using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webTimPhong.Models.EF
{
    [Table("ROOMDetail")]
    public class ROOMDetail
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? RoomId { get; set; }

        [StringLength(300)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Giá")]
        public decimal Price { get; set; }
        [Display(Name = "Diện tích")]
        public int Acreage { get; set; }
        [Display(Name = "Số phòng")]
        public int RoomNumber { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Thông tin chi tiết")]
        public string Description { get; set; }
        [Display(Name = "Nhá vệ sinh riêng")]
        public bool HasPrivateWC { get; set; }
        [Display(Name = "Gác lửng")]
        public bool HasMezzanine { get; set; }
        [Display(Name = "Nấu ăn")]
        public bool AllowCook { get; set; }
        [Display(Name = "Giá nước")]
        public int? WaterPrice { get; set; }
        [Display(Name = "Giá điện")]
        public int? ElectronicPrice { get; set; }
        [Display(Name = "Giá wifi")]
        public decimal? WifiPrice { get; set; }
        [Display(Name = "Camera an ninh")]
        public bool SecurityCamera { get; set; }
        
        public virtual ROOM ROOM { get; set; }
    }
}