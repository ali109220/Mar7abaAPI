using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalApiMarhaba.Models
{
    public class Company
    {
        public Company()
        {
            this.Branches = new List<Branch>();
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

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Facebook { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Instagram { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Twitter { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Youtube { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Email { get; set; }

        public virtual List<Branch> Branches { get; set; }
    }
}