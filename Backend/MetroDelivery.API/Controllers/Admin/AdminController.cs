using MetroDelivery.Application.Features.Customers.Queries.GetCustomerById;
using MetroDelivery.Application.Features.Customers;
using Microsoft.AspNetCore.Mvc;
using MetroDelivery.Application.Features.Customers.Queries.GetByIdForAdmin;
using MediatR;
using MetroDelivery.Application.Features.Customers.Queries.GetAllForAdmin;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MetroDelivery.API.Controllers.Admin
{
    [Route("api/v1/admins")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        /*[Authorize(Roles = "Admin")]*/
        public async Task<ActionResult<List<CustomerResponse>>> GetAllUser()
        {
            try {
                var response = await _mediator.Send(new GetListForAdminQuery());
                return response;
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{applicationuserid}")]
        /*[Authorize(Roles = "Admin, EndUser")]*/
        // đang get detail cho cả 4 role, đổi tên lại
        public async Task<ActionResult<CustomerRole>> GetUserById(string applicationuserid)
        {
            var request = new GetByIdForAdminQuery(applicationuserid);
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
