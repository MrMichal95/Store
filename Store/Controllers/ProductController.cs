using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Domain.Abstract;

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
            return View(!string.IsNullOrEmpty(category) ? repository.Products.Where(x => x.Category == category) : repository.Products);
        }
    }
}