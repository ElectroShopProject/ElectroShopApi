using System;
using System.Net;
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

        [Route("complete")]
        [HttpPost]
        public IActionResult Complete()
        {
            // TODO Finish
            return new OkResult();
        }

        [Route("pay")]
        [HttpPost]
        public IActionResult Pay()
        {
            // TODO Finish
            return new OkResult();
        }
    }
}
