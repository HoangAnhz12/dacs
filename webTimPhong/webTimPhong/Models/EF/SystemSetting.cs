using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webTimPhong.Models.EF
{
    [Table("SystemSetting")]
    public class SystemSetting
    {
        [Key]
        [StringLength(100)]
        public string settingkey { get; set; }
        [StringLength(1000)]
        public string settingvalue { get; set; }
        public string settingdescription { get; set; }
    }
}