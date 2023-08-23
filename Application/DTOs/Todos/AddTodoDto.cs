using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Todos
{
    public class AddTodoDto
    {
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 10)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool HasCompleted { get; set; }

        [Required]
        [Range(1, double.PositiveInfinity)]
        public int CategoryId { get; set; }
    }
}
