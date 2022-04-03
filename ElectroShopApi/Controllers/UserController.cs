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

        public UserController(OrderService orderService)
        {
            _orderService = orderService;
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
