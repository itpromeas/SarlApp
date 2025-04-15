using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebApp.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Product Title")]
        [Required]
        [MaxLength(50)]
        public required string Title { get; set; }
        public string? Description { get; set; }

        [Required]
        [Range(1, 1000000)]
        [DisplayName("List Price")]
        public double ListPrice { get; set; }

        [Required]
        [Range(1, 1000000)]
        [DisplayName("Price for 1 to 50")]
        public double Price { get; set; }

        [Required]
        [Range(1, 1000000)]
        [DisplayName("Price for 50 to 100")]
        public double Price50 { get; set; }

        [Required]
        [Range(1, 1000000)]
        [DisplayName("Price for more than 100")]
        public double Price100 { get; set; }

        public string Author { get; set; }
    }
}
