using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Categories
{
    public class UpdateCategoryDto : AddCategoryDto
    {
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Id must be greater than 0")]
        public int Id { get; set; }
    }
}
