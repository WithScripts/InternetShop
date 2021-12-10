using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public enum UserRole
    {
        Admin,
        User
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [HiddenInput(DisplayValue = false)]
        public UserRole Role { get; set; }
        public ICollection<ProductUser> ProdcutUsers;
        public User()
        {
            ProdcutUsers = new List<ProductUser>();
        }
    }
}
