using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalApiMarhaba.Models
{
    public class Type
    {
        public Type()
        {
            this.Deals = new List<Deal>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string ResourceName { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string ResourceDescription { get; set; }

        public int Category_Id { get; set; }
        [ForeignKey("Category_Id")]
        public virtual Category Category { get; set; }
        public virtual List<Deal> Deals { get; set; }

    }
}