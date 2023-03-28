using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TakeawayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public ActionResult<string> GetOrder()
        {
            return "You get an order";
        }
    }
}
