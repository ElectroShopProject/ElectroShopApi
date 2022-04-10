using System;
using System.Net;
using ElectroShopApi.Services;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace ElectroShopApi.Controllers
{
    [Route("user")]
    public class UserController
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
        public IActionResult PostLogin([FromBody] LoginUserRequest request)
        {
            try
            {
                var user = _userService.GetUser(request.Name);
                if (user != null)
                {
                    return new JsonResult(user);
                }

                return new JsonResult(_userService.CreateUser(request.Name));
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
                var orders = _orderService.GetOrders(userId);
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
