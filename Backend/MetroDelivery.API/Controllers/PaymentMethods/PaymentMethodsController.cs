using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Features.Orders.Commands.CreateOrder;
using MetroDelivery.Application.Features.PaymentMethods.Queries;
using MetroDelivery.Application.Features.PaymentMethods.Queries.GetAllPaymentMethod;
using MetroDelivery.Application.Features.PaymentMethods.Queries.GetByIdPaymentMethod;
using MetroDelivery.Application.Features.PaymentMethods.Queries.GetPaymentHistory;
using MetroDelivery.Application.Models.VnPay;
using MetroDelivery.Identity.Services.VnPay;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MetroDelivery.API.Controllers.PaymentMethods
{
    [Route("api/v1/payment-methods")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IVnPayService _vnPayService;

        public PaymentMethodsController(IMediator mediator, IVnPayService vnPayService)
        {
            _mediator = mediator;
            _vnPayService = vnPayService;
        }

        [HttpGet]
        public async Task<List<PaymentMethodResponse>> GetAll()
        {
            var response = await _mediator.Send(new GetListPaymentMethodQuery());
            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PaymentMethodResponse>> GetUserById(string id)
        {
            var response = await _mediator.Send(new GetByIdPaymentMethodQuery
            {
                Id = id
            });
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        /*[Authorize(Roles = "EndUser")]*/
        public IActionResult CreateOrder([FromBody] PaymentInformation request)
        {
            if (ModelState.IsValid) {
                var url = _vnPayService.CreatePaymentUrl(request, HttpContext);
                var response = new PaymentUrlResponse { PaymentUrl = url };
                return Ok(response);
            }
            else {
                return BadRequest("Invalid payment information.");
            }
        }

        [HttpPost("PaymentCallback")]
        public IActionResult PaymentCallback()
        {
            IQueryCollection queryCollection = HttpContext.Request.Query;

            // Execute the payment and get the response
            PaymentResponse paymentResponse = _vnPayService.PaymentExecute(queryCollection);

            /*var response = _vnPayService.PaymentExecute(Request.Query);*/
            return Ok(paymentResponse);
        }

        // history
        [HttpGet]
        [Route("get-payment-history-by-order-id")]
        public async Task<ActionResult<PaymentMethodResponse>> Get([FromQuery] GetPaymentHistoryQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }

    public class PaymentUrlResponse
    {
        public string PaymentUrl { get; set; }
    }
}
