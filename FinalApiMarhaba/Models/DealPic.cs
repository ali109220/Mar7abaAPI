using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalApiMarhaba.Models
{
    public class DealPic
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Url { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string ResourceName { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string ResourceDescription { get; set; }

        public int PicOrder { get; set; }
        public int Deal_Id { get; set; }

        [ForeignKey("Deal_Id")]
        public virtual Deal Deal { get; set; }
    }
}