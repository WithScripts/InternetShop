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
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IList<User> GetUsers() =>
            RepositoryContext.Users.ToList();
        public void Create(User user) => base.Create(user);
        public void Delete(User user) => base.Delete(user);
        public void Update(User user) => base.Update(user);
    }
}
