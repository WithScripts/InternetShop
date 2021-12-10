using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetShop.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepositoryManager _repositoryContext;
        public UserController(IRepositoryManager repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
