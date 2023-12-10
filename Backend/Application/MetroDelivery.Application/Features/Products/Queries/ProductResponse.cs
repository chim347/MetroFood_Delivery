using MetroDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Products.Queries
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        [ForeignKey("Category")]
        public Guid CategoryID { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string Image { get; set; }
        public double? Price { get; set; }
        public DateTime Created { get; set; }

        public Category? CategoryData { get; set; }
    }
}
