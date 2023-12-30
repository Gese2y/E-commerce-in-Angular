using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
var products = _context.Products.ToList();
return Ok(products);
        }
        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return "get single product";
        }
        
    }
}