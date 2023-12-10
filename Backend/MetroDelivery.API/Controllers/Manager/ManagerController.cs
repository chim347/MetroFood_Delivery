using MediatR;
using MetroDelivery.Application.Features.Customers.Queries.GetAllForAdmin;
using MetroDelivery.Application.Features.Customers;
using Microsoft.AspNetCore.Mvc;
using MetroDelivery.Application.Features.Manager.Queries;
using MetroDelivery.Application.Features.Manager.Queries.GetAllManager;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Features.Staff.Commands.CreateStaff;
using MetroDelivery.Application.Features.Staff.Commands.DeleteStaff;
using MetroDelivery.Application.Features.Staff.Commands.UpdateStaff;
using MetroDelivery.Application.Features.Staff.Queries.GetByIdStaff;
using MetroDelivery.Application.Features.Staff.Queries;
using MetroDelivery.Application.Features.Manager.Queries.GetByIdStaff;
using MetroDelivery.Application.Features.Manager.Commands.CreateManager;
using MetroDelivery.Application.Features.Manager.Commands.DeleteManager;
using MetroDelivery.Application.Features.Manager.Commands.UpdateManager;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MetroDelivery.API.Controllers.Manager
{
    [Route("api/v1/managers")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ManagerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ManagerRole>>> Get()
        {
            try {
                var response = await _mediator.Send(new GetListManagerQuery());
                return response;
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{applicationuserid}")]
        public async Task<ActionResult<ManagerRole>> Get(string applicationuserid)
        {
            var request = new GetByIdManagerQuery(applicationuserid);
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Create([FromBody] CreateManagerCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<MetroPickUpResponse> Update([FromBody] UpdateManagerCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpDelete]
        [Route("{applicationuserid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<MetroPickUpResponse> Delete(string applicationuserid)
        {
            var request = new DeleteManagerCommand { Id = applicationuserid };
            var response = await _mediator.Send(request);
            return response;
        }
    }
}
