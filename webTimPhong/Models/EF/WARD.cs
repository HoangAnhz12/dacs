namespace webTimPhong.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WARD")]
    public partial class WARD
    {
        public WARD()
        {
            ROOMs = new HashSet<ROOM>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string WardName { get; set; }

        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public virtual DISTRICT DISTRICT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROOM> ROOMs { get; set; }
    }
}
