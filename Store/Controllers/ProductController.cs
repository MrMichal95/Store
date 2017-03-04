using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Domain.Abstract;
using Store.Models;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        public ViewResult List()
        {
            return View(repository.Products);
        }
        public ViewResult ListFiltered(string category)
        {
            ProductViewModel productViewModel = null;
            productViewModel = category != null
                ? new ProductViewModel
                {
                    CurrentCategory = category,
                    Products = repository.Products.Where(p => p.Category == category)
                }
                : new ProductViewModel
                {
                    CurrentCategory = "All",
                    Products = repository.Products
                };

            return View(productViewModel);
        }
    }
}