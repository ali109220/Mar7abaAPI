using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity; 

namespace FinalApiMarhaba.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string UserName { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string FisrtName { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string LastName { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Password { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Email { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Phone { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LastLogin { get; set; }

        public int LoginCounts { get; set; }

        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }

        public bool Confirmed { get; set; }

        public int BuyingTimes { get; set; }

        public double BuyingValue { get; set; }
    }
}