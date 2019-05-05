using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalApiMarhaba.Models
{
    public class ShopCartOption
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public double Value { get; set; }

        public int Quantity { get; set; }
        public int Option_Id { get; set; }
        public int ShopCart_Id { get; set; }
        [ForeignKey("Option_Id")]
        public virtual Option Option { get; set; }
        [ForeignKey("ShopCart_Id")]
        public virtual ShopCart ShopCart { get; set; }
      
    }
}