namespace webTimPhong.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("ROOM")]
    public class ROOM : CommonAbstract
    {
        public ROOM()
        {
            PICTUREs = new HashSet<PICTURE>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserID { get; set; }


        [StringLength(300)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Giá")]
        public decimal Price { get; set; }
        [Display(Name = "Diện tích")]
        public int Acreage { get; set; }
        [Display(Name = "Số phòng")]
        public int RoomNumber { get; set; }
        [Required]

        [Display(Name = "Thông tin chi tiết")]
        public string Description { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int WardId { get; set; }
        public int? DistrictId { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        [Display(Name = "thời gian hết hạn")]
        public DateTime ExprireTime { get; set; }
        [Display(Name = "Hinh anh")]
        public string Image { get; set; }
        [Required]
        public int RoomCategoryId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longtitude { get; set; }
        public int ViewCount { get; set; }

        public bool IsConfirm  { get; set; }        
       public virtual ICollection<PICTURE> PICTUREs { get; set; }
        public virtual WARD WARD { get; set; }
        public virtual CITY CITY { get; set; }
        public virtual DISTRICT DISTRICT { get; set; }
        public virtual RoomCategory RoomCategory { get; set; }

    }
}
