using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Models
{
    public class Cart
    {
        [Key]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Display(Name = ("Added To Cart"))]
        public DateTime AddedAt { get; set; }

        public virtual Product Product { get; set; }
    }
}