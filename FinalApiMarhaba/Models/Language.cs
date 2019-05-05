using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalApiMarhaba.Models
{
    public class Language
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Culture { get; set; }

        public bool IsActive { get; set; }

        public bool Direction { get; set; }
    }
}