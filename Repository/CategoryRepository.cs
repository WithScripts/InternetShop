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
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IList<Category> GetCategories() => 
            RepositoryContext.Categories.Include(c => c.Products).ToList();
        public void Create(Category category) => base.Create(category);
        public void Delete(Category category) => base.Delete(category);
        public void Update(Category category) => base.Update(category);
    }
}
