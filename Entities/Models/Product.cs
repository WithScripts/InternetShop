using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Cost { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Picture { get; set; }
        public ICollection<Category> Categories;
        public ICollection<ProductUser> ProdcutUsers;
        public Product()
        {
            Categories = new List<Category>();
            ProdcutUsers = new List<ProductUser>();
        }
    }
}
