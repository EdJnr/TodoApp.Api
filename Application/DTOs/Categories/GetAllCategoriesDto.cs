using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Categories
{
    public class GetAllCategoriesDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }    
        public DateTime Created { get; set; }
        public DateTime LastMiodified { get; set; }
    }
}
