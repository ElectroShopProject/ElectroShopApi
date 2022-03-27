using ElectroShopApi.Domain.Summary;
using Microsoft.AspNetCore.Mvc;

namespace ElectroShopApi.Controllers
{
    [ApiController]
    [Route("summary")]
    public class SummaryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Summary();
        }

        [Route("finalize")]
        [HttpPost]
        public IActionResult Finalize()
        {
            return PaymentRequirment;
        }
    }
}
