using H3_Serverside___Milk_and_Cookies.Extensions;
using H3_Serverside___Milk_and_Cookies.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace H3_Serverside___Milk_and_Cookies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        // GET: api/<ShoppingCartController>
        [HttpGet]
        public IEnumerable<Product> Get(string name, float price)
        {
            List<Product> products = HttpContext.Session.GetObjectFromJson<List<Product>>("ShoppingCart");
            if(products == null)
            {
                products = new List<Product>();
            } 

            Product createdProduct = new Product() { Name = name, Price = price };
            products.Add(createdProduct);

            HttpContext.Session.SetObjectAsJson("ShoppingCart", products);

            return products;
        }
    }
}
