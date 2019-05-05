using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalApiMarhaba.Models
{
    public class Condition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Description { get; set; }

        public int Order { get; set; }
        public int Deal_Id { get; set; }
        [ForeignKey("Deal_Id")]
        public virtual Deal Deal { get; set; }
    }
}