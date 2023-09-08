using H3_Serverside___Milk_and_Cookies.Extensions;
using H3_Serverside___Milk_and_Cookies.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace H3_Serverside___Milk_and_Cookies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCardRemover : ControllerBase
    {
        // DELETE api/<ShoppingCardRemover>/5
        [HttpDelete]
        public ActionResult Delete()
        {
            List<Product> products = HttpContext.Session.GetObjectFromJson<List<Product>>("ShoppingCart");
            if (products == null)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            products.RemoveAt(products.Count() - 1);

            HttpContext.Session.SetObjectAsJson("ShoppingCart", products);

            return StatusCode(StatusCodes.Status200OK, "Latest item removed");
        }
    }
}
