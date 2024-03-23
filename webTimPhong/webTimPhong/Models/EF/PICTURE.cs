using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webTimPhong.Models.EF
{
    [Table("PICTURE")]
    public class PICTURE 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int RoomId { get; set; }

        [Required]
        [StringLength(300)]
        public string Image1 { get; set; }
        [Required]
        [StringLength(300)]
        public string Image2 { get; set; }
        [Required]
        [StringLength(300)]
        public string Image3 { get; set; }
        [Required]
        [StringLength(300)]
        public string Image4 { get; set; }
        [Required]
        [StringLength(300)]
        public string Image5 { get; set; }

        public bool IsActive { get; set; }

        public virtual ROOM ROOM { get; set; }
    }
}