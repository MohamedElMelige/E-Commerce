using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Range(1000, 100000)]
        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public double Price { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [ForeignKey("Category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Cart Cart { get; set; }
    }
}