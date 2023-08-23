using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Persistence.Seedings
{
    internal class CategorySeeding
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Category 1", Created = DateTime.UtcNow, LastModified = DateTime.UtcNow },
                new Category { Id = 2, Name = "Category 2", Created = DateTime.UtcNow, LastModified = DateTime.UtcNow },
                new Category { Id = 3, Name = "Category 3", Created = DateTime.UtcNow, LastModified = DateTime.UtcNow },
                new Category { Id = 4, Name = "Category 4", Created = DateTime.UtcNow, LastModified = DateTime.UtcNow },
                new Category { Id = 5, Name = "Category 5", Created = DateTime.UtcNow, LastModified = DateTime.UtcNow },
                new Category { Id = 6, Name = "Category 6", Created = DateTime.UtcNow, LastModified = DateTime.UtcNow });
        }
    }
}
