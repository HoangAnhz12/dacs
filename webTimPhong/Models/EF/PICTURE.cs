namespace webTimPhong.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PICTURE")]
    public partial class PICTURE
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int RoomId { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }

        public virtual ROOM ROOM { get; set; }
    }
}
