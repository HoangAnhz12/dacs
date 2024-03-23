using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webTimPhong.Models.EF
{
    [Table("DISTRICT")]
    public class DISTRICT 
    {
        public DISTRICT()
        {
            this.ROOMs = new HashSet<ROOM>();
            this.WARDs = new HashSet<WARD>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string DistrictName { get; set; }

        public int CityId { get; set; }

        public virtual CITY CITY { get; set; }

       
        public virtual ICollection<ROOM> ROOMs { get; set; }

        
        public virtual ICollection<WARD> WARDs { get; set; }
    }
}