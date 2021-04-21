using Core.RequestModels;
using Core.ResponseModels;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AcquirerClientApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcquirerController : ControllerBase
    {

        private readonly ILogger<AcquirerController> _logger;
        private readonly IPaymentService _paymentService;

        public AcquirerController(ILogger<AcquirerController> logger, IPaymentService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PaymentCallback")]

        public async Task PaymentCallback([FromQuery] CallbackRequest request)
        {
            await _paymentService.RegiisterCallBack(request, EnumCollbackType.Payment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("RefundCallback")]
        public async Task RefundCallback([FromQuery] CallbackRequest request)
        {
            await _paymentService.RegiisterCallBack(request, EnumCollbackType.Refund);
        }

        [HttpPost]
        [Route("Pay")]
        public async Task<IActionResult> Payment([FromBody] AddPaymentRequest request)
        {

            var result = await _paymentService.Pay(request);

            if (result.Succeeded)
                return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        //[HttpGet]
        //[Route("checkAvailable")]
        //public async Task<IActionResult> CheckPaymentAvail([FromQuery] CheckPaymentAvailRequest request)
        //{

        //    if (!int.TryParse(request.PaymentId, out int paymentId))
        //    {
        //        return Content(GeorgianCardHelper.BuildPaymentAvailableResponse(ResultCode.Fail, "Invalid o.id."));
        //    }

        //    //var payment = await _context.Payments.FindAsync(paymentId);

        //    //if (payment == null)
        //    //{
        //    //    return Content(GeorgianCardHelper.BuildPaymentAvailableResponse(ResultCode.Fail, "Payment not found."));
        //    //}

        //    if (string.IsNullOrWhiteSpace(request.MerchantId) /*|| request.MerchantId != _config.MerchantId*/)
        //    {
        //        return Content(GeorgianCardHelper.BuildPaymentAvailableResponse(ResultCode.Fail, "Invalid merch_id."));
        //    }


        //    if (string.IsNullOrWhiteSpace(request.TransactionId))
        //    {
        //        return Content(GeorgianCardHelper.BuildPaymentAvailableResponse(ResultCode.Fail, "Invalid trx_id."));
        //    }

        //    //payment.ExternalId = request.TransactionId;

        //    //_context.Update(payment);
        //    //await _context.SaveChangesAsync();

        //    var paymentAmount = GeorgianCardHelper.ConvertGELToGeorgianCardAmount(7/*payment.Amount*/);


        //    return Content(GeorgianCardHelper.BuildPaymentAvailableResponse(ResultCode.Success, ResultCode.Success.ToString(), paymentAmount, "ShoortDesc", "LongDesc", "MenrchantId", "GEL", ""));

        //}

        //[HttpGet]
        //[Route("registerPayment")]
        //public async Task<Registerpaymentresponse> RegisterPayment(CheckPaymentAvailRequest request)
        //{


        //    return new Registerpaymentresponse();
        //}


        //[HttpGet]
        //[Route("success")]
        //public async Task Success(string orderId)
        //{
        //    await _paymentService.PaymentSuceeded(orderId);
        //}

        //[HttpGet]
        //[Route("fail")]
        //public async Task Fail(string orderId)
        //{
        //    await _paymentService.PaymentFailed(orderId);
        //}
    }
}
