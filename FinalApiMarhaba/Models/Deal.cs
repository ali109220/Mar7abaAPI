using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity; 

namespace FinalApiMarhaba.Models
{
    public class Deal
    {
        public Deal()
        {
            this.Conditions = new List<Condition>();
            this.DealPics = new List<DealPic>();
            this.Highlights = new List<Highlight>();
            this.Options = new List<Option>();
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
        public string ResourceMoreInfo { get; set; }

        public int PaysCount { get; set; }

        public int Limited { get; set; }

        public bool IsLimited { get; set; }
        public bool ISForAdvertisement { get; set; }
        public bool IsViewedInCategoryArea { get; set; }
        [Column(TypeName = "date")]
        public DateTime? AddDate { get; set; }

        public int Clicks { get; set; }

        public int Rate { get; set; }
        public int City_Id { get; set; }
        public int Company_Id { get; set; }
        public int Type_Id { get; set; }

        [ForeignKey("City_Id")]
        public virtual City City { get; set; }
        [ForeignKey("Company_Id")]
        public virtual Company Company { get; set; }
        [ForeignKey("Type_Id")]
        public virtual Type Type { get; set; }
        public virtual List<Condition> Conditions { get; set; }
        public virtual List<DealPic> DealPics { get; set; }
        public virtual List<Highlight> Highlights { get; set; }
        public virtual List<Option> Options { get; set; }

    }
}