using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICategoryRepository
    {
        IList<Category> GetCategories();
        public void Create(Category category);
        public void Delete(Category category);
        public void Update(Category category);
    }
}
