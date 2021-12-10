using Contracts;
using Entities.DataTransferObject;
using Entities.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InternetShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepositoryManager _repositoryManager;
        public AccountController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                User user = _repositoryManager.User.GetUsers()
                    .FirstOrDefault(u => u.Email == loginDto.Email && u.Password == loginDto.Password);
                if(user != null)
                {
                    //await Authenticate(loginDto.Email);
                    if(((int)user.Role) == 1)
                    {
                        HttpContext.Response.Cookies.Append("id", user.Id.ToString());
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return BadRequest("Вы не администратор");
                    }
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(loginDto);
        }
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("id");
            return RedirectToAction("Index", "Home");
        }
        //private async Task Authenticate(string userName)
        //{
        //    // создаем один claim

        //    // установка аутентификационных куки
        //    await 
        //}

    }
}
