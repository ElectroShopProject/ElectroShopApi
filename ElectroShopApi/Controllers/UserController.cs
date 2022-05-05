using System;
using System.Net;
using System.Threading.Tasks;
using ElectroShopApi.Services;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace ElectroShopApi.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly UserService _userService;

        public UserController(OrderService orderService, UserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        // POST /user/login
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> PostLogin([FromBody] LoginUserRequest request)
        {
            try
            {
                var user = await _userService.GetUser(request.Name);
                if (user != null)
                {
                    return new JsonResult(user);
                }

                return new JsonResult(await _userService.CreateUser(request.Name));
            }
            catch (Exception)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        // GET /user/orders
        [Route("orders")]
        [HttpGet]
        public IActionResult GetOrders([FromQuery] Guid userId)
        {
            try
            {
                var orders = _orderService.GetOrdersAsync(userId);
                return new JsonResult(orders);
            }
            catch (NullReferenceException)
            {
                return new NotFoundObjectResult("Cannot find orders for this user.");
            }
            catch (Exception)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
