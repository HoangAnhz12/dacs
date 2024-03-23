using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webTimPhong.Models.EF
{
    [Table("CITY")]
    public class CITY 
    {
        public CITY()
        {
            DISTRICTs = new HashSet<DISTRICT>();
            MAPs = new HashSet<MAP>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CityName { get; set; }

        public virtual ICollection<DISTRICT> DISTRICTs { get; set; }      
        public virtual ICollection<MAP> MAPs { get; set; }
    }
}