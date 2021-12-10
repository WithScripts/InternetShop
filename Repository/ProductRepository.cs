using Contracts;
using Entiies;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IList<Product> GetProducts() => 
            RepositoryContext.Products.Include(p => p.Categories).ToList();
        public void Create(Product product) => base.Create(product);
        public void Delete(Product product) => base.Delete(product);
        public void Update(Product product) => base.Update(product);
    }
}
