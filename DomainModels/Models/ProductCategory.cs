using DomainModels.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class ProductCategory : Entity
    {
        public string ProductCategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
