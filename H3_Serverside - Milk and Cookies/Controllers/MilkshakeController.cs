using H3_Serverside___Milk_and_Cookies.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace H3_Serverside___Milk_and_Cookies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilkshakeController : ControllerBase
    {
        /// <summary>
        /// Storing Cookie names for reference
        /// </summary>
        private Dictionary<string, string> _cookieNames = new Dictionary<string, string>()
        {
            { nameof(MilkshakeFlavour), "favoritFlavour" }
        };

        // GET: api/<MilkshakeController>
        [HttpGet]
        public ActionResult<string> Get(string favoritFlavour)
        {
            MilkshakeFlavour flavour;
            if(Enum.TryParse<MilkshakeFlavour>(favoritFlavour, ignoreCase: true, out flavour) == false)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Flavour is not available");
            }

            CookieOptions cookieOptions = new CookieOptions()
            {
                MaxAge = TimeSpan.FromMinutes(5)
            };

            Response.Cookies.Append(_cookieNames[nameof(MilkshakeFlavour)], flavour.ToString(), cookieOptions);

            return StatusCode(StatusCodes.Status200OK, flavour.ToString());
        }

        // GET: api/<MilkshakeController>/GetFromCookie
        [HttpGet("[action]")]
        public ActionResult<string> GetFromCookie()
        {
            string? flavourFromCookie = Request.Cookies[_cookieNames[nameof(MilkshakeFlavour)]]; // Get cookie name from Name dictionary

            // Check if cookie exist
            if(string.IsNullOrWhiteSpace(flavourFromCookie))
            {
                return StatusCode(StatusCodes.Status404NotFound, "Unknown favorit flavour");
            }

            MilkshakeFlavour flavour;
            if (Enum.TryParse<MilkshakeFlavour>(flavourFromCookie, ignoreCase: true, out flavour) == false)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Flavour is not available");
            }

            return StatusCode(StatusCodes.Status200OK, flavour.ToString());
        }

        // GET: api/<MilkshakeController>/DeleteCookie
        [HttpDelete("[action]")]
        public ActionResult<string> DeleteCookie()
        {
            string? flavourFromCookie = Request.Cookies[_cookieNames[nameof(MilkshakeFlavour)]]; // Get cookie name from Name dictionary

            // Check if cookie exist
            if (string.IsNullOrWhiteSpace(flavourFromCookie))
            {
                return StatusCode(StatusCodes.Status404NotFound, "Unknown favorit flavour");
            }

            Response.Cookies.Delete(_cookieNames[nameof(MilkshakeFlavour)]);

            return StatusCode(StatusCodes.Status200OK, "Cookie deleted. Value: " + flavourFromCookie);
        }
    }
}
