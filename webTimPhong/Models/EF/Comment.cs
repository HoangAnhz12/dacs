using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webTimPhong.Models.EF
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string CommentMsg { get; set; }
        [Required]
        public DateTime CommentDate { get; set; }
        public int RoomId { get; set; }
        [Required]
        [StringLength(128)]
        public string UserID { get; set; }
        public virtual ROOM ROOM { get; set; }
    }
}