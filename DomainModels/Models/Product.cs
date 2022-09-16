using DomainModels.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class Product : Entity
    {
        public string ProductName { get; set; }

        public int ProductCategoryId { get; set; }

        public ProductCategory? ProductCategory { get; set; }

        public double Price { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? State { get; set; }

        public bool IsDeleted { get; set; }
    }
}
