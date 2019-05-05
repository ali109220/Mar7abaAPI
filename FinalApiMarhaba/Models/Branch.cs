using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalApiMarhaba.Models
{
    public class Branch
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string ResourceName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string TopRight { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string BottomLeft { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Tel { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string ResourceNearLocation { get; set; }
        public int Company_Id { get; set; }
        [ForeignKey("Company_Id")]
        public virtual Company Company { get; set; }
    }
}