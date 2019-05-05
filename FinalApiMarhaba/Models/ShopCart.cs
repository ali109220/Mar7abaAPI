using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalApiMarhaba.Models
{
    public class ShopCart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public bool IsBuyed { get; set; }
        public int User_Id { get; set; }
        [ForeignKey("User_Id")]
        public virtual User User { get; set; }
        public virtual List<ShopCartOption> ShopCartOptions { get; set; }
      
    }
}