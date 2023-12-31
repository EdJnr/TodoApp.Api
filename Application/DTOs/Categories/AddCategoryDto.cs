﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Categories
{
    public class AddCategoryDto
    {
        [Required]
        [StringLength(maximumLength: 20)]
        public string Name { get; set; }
    }
}
