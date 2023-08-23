using Domain.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Todo: BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool HasCompleted { get; set; }

        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set;}

        public Category? Category { get; set; }
    }
}
