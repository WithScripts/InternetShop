using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IRepositoryManager _repositoryContext;
        public ProductsController(IRepositoryManager repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IActionResult Index()
        {
            IList<Product> products = _repositoryContext.Product.GetProducts();
            return products.Count != 0 ? View(products) : BadRequest("No data");
        }
        public IActionResult ProductsByCategory(int id)
        {
            Category category = _repositoryContext.Category.GetCategories().FirstOrDefault(a => a.Id == id);
            if (category == null) return BadRequest("Category not exist");
            return View(category.Products);

        }
    }
}
