using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webTimPhong.Models.EF
{
    [Table("MAP")]
    public class MAP 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Address { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longtitude { get; set; }

        public int? WardId { get; set; }

        public int? DistrictId { get; set; }

        public int? CityId { get; set; }

        public int RoomId { get; set; }

        public virtual CITY CITY { get; set; }

        public virtual DISTRICT DISTRICT { get; set; }

        public virtual ROOM ROOM { get; set; }

        public virtual WARD WARD { get; set; }
    }
}