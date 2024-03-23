using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webTimPhong.Models.EF
{
    [Table("FAQ")]
    public class FAQ 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string HoTen { get; set; }

        public int Phone { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string Question { get; set; }
    }
}