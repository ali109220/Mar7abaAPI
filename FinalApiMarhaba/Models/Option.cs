using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalApiMarhaba.Models
{
    public class Option
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Name { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string ResourceDescription { get; set; }

        public double Price { get; set; }
        public double OldPrice { get; set; }
        public bool IsContainsDiscount { get; set; }
        public int DiscountPercentage { get; set; }


        public int Deal_Id { get; set; }
        [ForeignKey("Deal_Id")]
        public virtual Deal Deal { get; set; }
    }
}