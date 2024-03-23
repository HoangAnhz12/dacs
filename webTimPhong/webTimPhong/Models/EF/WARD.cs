using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webTimPhong.Models.EF
{
    [Table("WARD")]
    public class WARD 
    {
        public WARD()
        {
            MAPs = new HashSet<MAP>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string WardName { get; set; }

        public int? DistrictId { get; set; }

        public virtual DISTRICT DISTRICT { get; set; }

        public virtual ICollection<MAP> MAPs { get; set; }
    }
}