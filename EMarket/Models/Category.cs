using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMarket.Models
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Number Of Products")]
        public int NumberOfProducts { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}