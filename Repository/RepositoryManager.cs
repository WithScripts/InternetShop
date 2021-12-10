using Contracts;
using Entiies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        public RepositoryContext RepositoryContext;
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private IUserRepository _userRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public IProductRepository Product
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(RepositoryContext);
                return _productRepository;
            }
        }
        public ICategoryRepository Category
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(RepositoryContext);
                return _categoryRepository;
            }
        }
        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(RepositoryContext);
                return _userRepository;
            }
        }

        public void Save() => RepositoryContext.SaveChanges();
    }
}
