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
        public required string Name { get; set; }

        [DisplayName("Category Order")]
        public int DisplayOrder { get; set; }
    }
}