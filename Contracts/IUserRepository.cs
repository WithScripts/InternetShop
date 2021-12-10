using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserRepository
    {
        IList<User> GetUsers();
        public void Create(User user);
        public void Delete(User user);
        public void Update(User user);
    }
}
