using Contracts;
using Entities.DataTransferObject;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepositoryManager _repositoryManager;
        public AdminController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public IActionResult Index()
        {
            if (!CheckAdmin()) return BadRequest("Вы не администратор");
            return View(_repositoryManager);
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductForCreationDto productDto)
        {
            if (!CheckAdmin()) return BadRequest("Вы не администратор");
            var product = new Product
            {
                Title = productDto.Title,
                Quantity = productDto.Quantity,
                Cost = productDto.Cost,
                Description = productDto.Description,
                Picture = productDto.Description
            };
            Category category = _repositoryManager.Category.GetCategories().FirstOrDefault(c => c.Id == productDto.CategoryId);
            if(category != null)
                product.Categories.Add(category);
            _repositoryManager.Product.Create(product);
            _repositoryManager.Save();
            return RedirectToAction("Index");
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(CategoryForCreationDto categoryDto)
        {
            if (!CheckAdmin()) return BadRequest("Вы не администратор");
            var category = new Category
            {
                Title = categoryDto.Title
            };
            _repositoryManager.Category.Create(category);
            _repositoryManager.Save();
            return RedirectToAction("Index");
        }
        public IActionResult EditProduct(int id)
        {
            var product = _repositoryManager.Product.GetProducts().FirstOrDefault(c => c.Id == id);
            ProductForCreationDto productDto = new()
            {
                Id = product.Id,
                Title = product.Title,
                Quantity = product.Quantity,
                Description = product.Description,
                Cost = product.Cost,
                Picture = product.Picture
            };
            return View(productDto);
        }
        [HttpPost]
        public IActionResult EditProduct(ProductForCreationDto productDto)
        {
            var product = _repositoryManager.Product.GetProducts().FirstOrDefault(c => c.Id == productDto.Id);
            product.Title = productDto.Title;
            product.Quantity = productDto.Quantity;
            product.Cost = productDto.Cost;
            product.Description = productDto.Description;
            product.Picture = productDto.Description;
            _repositoryManager.Product.Update(product);
            _repositoryManager.Save();
            return RedirectToAction("Index");
        }
        public IActionResult EditCategory(int id)
        {
            var category = _repositoryManager.Category.GetCategories().FirstOrDefault(c => c.Id == id);
            CategoryForCreationDto categoryDto = new()
            {
                Id = category.Id,
                Title = category.Title
            };
            return View(categoryDto);
        }
        [HttpPost]
        public IActionResult EditCategory(CategoryForCreationDto categoryDto)
        {
            var category = _repositoryManager.Category.GetCategories().FirstOrDefault(c => c.Id == categoryDto.Id);
            category.Title = categoryDto.Title;
            _repositoryManager.Category.Update(category);
            _repositoryManager.Save();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(int prodcutId)
        {
            if (!CheckAdmin()) return BadRequest("Вы не администратор");
            Product product = _repositoryManager.Product.GetProducts().FirstOrDefault(c => c.Id == prodcutId);
            if (product == null) return BadRequest("Продукт не найден");
            _repositoryManager.Product.Delete(product);
            _repositoryManager.Save();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCategory(int categoryId)
        {
            if (!CheckAdmin()) return BadRequest("Вы не администратор");
            Category category = _repositoryManager.Category.GetCategories().FirstOrDefault(c => c.Id == categoryId);
            if (category == null) return BadRequest("Категория не найдена");
            _repositoryManager.Category.Delete(category);
            _repositoryManager.Save();
            return RedirectToAction("Index");
        }
        public IActionResult AddCategoryProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategoryProduct(ProductCategoryDto categoryDto)
        {
            if (!CheckAdmin()) return BadRequest("Вы не администратор");
            var category = _repositoryManager.Category.GetCategories().FirstOrDefault(c => c.Id == categoryDto.CategoryId);
            var product = _repositoryManager.Product.GetProducts().FirstOrDefault(c => c.Id == categoryDto.ProductId);
            if (category == null || product == null)
                return BadRequest("Продукт или категория не найденны");
            product.Categories.Add(category);
            _repositoryManager.Product.Update(product);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveCategoryProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RemoveCategoryProduct(ProductCategoryDto categoryDto)
        {
            if (!CheckAdmin()) return BadRequest("Вы не администратор");
            var category = _repositoryManager.Category.GetCategories().FirstOrDefault(c => c.Id == categoryDto.CategoryId);
            var product = _repositoryManager.Product.GetProducts().FirstOrDefault(c => c.Id == categoryDto.ProductId);
            if (category == null || product == null)
                return BadRequest("Продукт или категория не найденны");
            product.Categories.Remove(category);
            _repositoryManager.Product.Update(product);
            return RedirectToAction("Index");
        }
        private bool CheckAdmin()
        {
            int id = Convert.ToInt32(HttpContext.Request.Cookies["id"]);
            User user = _repositoryManager.User.GetUsers().FirstOrDefault(c => c.Id == id);
            if(user != null)
            {
                return (int)user.Role == 1 ? true : false;
            }
            return false;
        }
    }
}
