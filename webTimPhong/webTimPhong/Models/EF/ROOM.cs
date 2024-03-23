using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace webTimPhong.Models.EF
{
    [Table("ROOM")]
    public class ROOM
    {
        public ROOM()
        {
            MAPs = new HashSet<MAP>();
            PICTUREs = new HashSet<PICTURE>();
            ROOMDetails = new HashSet<ROOMDetail>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserID { get; set; }
        
        public DateTime PostTime { get; set; }

        public DateTime? LastUpdate { get; set; }

        public DateTime? ExprireTime { get; set; }

        public string ContactNumber { get; set; }

        public bool? IsConfirm { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime BeginTime { get; set; }
        public virtual ICollection<MAP> MAPs { get; set; }

        
        public virtual ICollection<PICTURE> PICTUREs { get; set; }

        
        public virtual ICollection<ROOMDetail> ROOMDetails { get; set; }
        
    }
}