using System;
using System.Net;
using System.Threading.Tasks;
using ElectroShopApi.Requests.Cart;
using Microsoft.AspNetCore.Mvc;

namespace ElectroShopApi.Controllers
{
    [ApiController]
    [Route("summary")]
    public class SummaryController : ControllerBase
    {

        private readonly SummaryService _summaryService;

        public SummaryController(SummaryService summaryService)
        {
            _summaryService = summaryService;
        }

        // GET /summary
        [HttpGet]
        public IActionResult Get([FromQuery] Guid cartId)
        {
            try
            {
                return new JsonResult(_summaryService.GetCartSummary(cartId));
            }
            catch (NullReferenceException)
            {
                return new NotFoundObjectResult("There is no cart with this ID");
            }
            catch (Exception)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        // POST /summary/completion
        [Route("completion")]
        [HttpPost]
        public IActionResult PostCompletion([FromBody] CompleteCartRequest request)
        {
            try
            {
                var paymentRequirment = _summaryService.GetPaymentRequirment(request.CartId);
                return new JsonResult(paymentRequirment);
            }
            catch (NullReferenceException)
            {
                return new NotFoundObjectResult("There is no cart with this ID");
            }
            catch (Exception)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        // POST /summary/payment
        [Route("payment")]
        [HttpPost]
        public async Task<IActionResult> PostPayment([FromBody] CartPaymentRequest request)
        {
            try
            {
                var order = await _summaryService.FinalizeCart(
                    request.CartId,
                    request.PaymentOptionType
                );
                return new JsonResult(order);
            }
            catch (Exception)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
