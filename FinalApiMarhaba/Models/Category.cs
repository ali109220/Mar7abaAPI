using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalApiMarhaba.Models
{
    public class Category
    {
        public Category()
        {
            this.Types = new List<Models.Type>();
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
        public virtual List<Type> Types { get; set; }

    }
}