using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProductRepository
    {
        IList<Product> GetProducts();
        public void Create(Product product);
        public void Delete(Product product);
        public void Update(Product product);
    }
}
