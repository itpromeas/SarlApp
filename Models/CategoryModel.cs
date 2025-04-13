using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SarlApp.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Category Name")]
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [DisplayName("Category Order")]
        [Range(1,100, ErrorMessage = "Display Order must be between 1-100!")] // this is a custom validation message
        public int DisplayOrder { get; set; }
    }
}