using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Controllers
{
    public class ProductController : Controller
    {

        private Product GetProduct()
        {
            return new Product()
            {
                Id = 1,
                Name = "Xbox One X",
                Description = "Jogue em 4k",
                Price = 2000.00M
            };
        }

        public ActionResult Visualizar()
        {
            Product product =  GetProduct();

            return View(product);
        }
    }
}
