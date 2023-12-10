using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Features.Staff.Commands.CreateStaff;
using MetroDelivery.Application.Features.Staff.Commands.DeleteStaff;
using MetroDelivery.Application.Features.Staff.Commands.UpdateStaff;
using MetroDelivery.Application.Features.Staff.Queries;
using MetroDelivery.Application.Features.Staff.Queries.GetAllStaff;
using MetroDelivery.Application.Features.Staff.Queries.GetByIdStaff;
using MetroDelivery.Application.Features.Staff.Queries.GetStaffByStoreId;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MetroDelivery.API.Controllers.Staff
{
    [Route("api/v1/staff")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StaffsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        /*[Authorize(Roles = "Manager, Staff")]*/
        public async Task<List<StaffRole>> Get()
        {
            var response = await _mediator.Send(new GetListStaffQuery());
            return response;
        }

        [HttpGet]
        [Route("{id}")]
        /*[Authorize(Roles = "Manager, Staff")]*/
        public async Task<ActionResult<StaffRole>> GetUserById(string id)
        {
            var response = await _mediator.Send(new GetByIdStaffQuery(id));
            return Ok(response);
        }

        [HttpGet]
        [Route("stores/{storeid}")]
        /*[Authorize(Roles = "Manager, Staff")]*/
        public async Task<ActionResult<StaffRole>> Get(string storeid)
        {
            var response = await _mediator.Send(new GetStaffByStoreIdQuery
            {
                StoreId = storeid
            });
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        /*[Authorize(Roles = "Manager")]*/
        public async Task<MetroPickUpResponse> CreateCustomer(CreateStaffCommand request)
        {
            var response = await _mediator.Send(request);
            return response;   
        }

        [HttpPut]
        
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        /*[Authorize(Roles = "Manager")]*/
        public async Task<MetroPickUpResponse> UpdateCustomer(UpdateStaffCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        /*[Authorize(Roles = "Manager")]*/
        public async Task<MetroPickUpResponse> Delete(string id)
        {
            var response = await _mediator.Send(new DeleteStaffCommand
            {
                Id = id
            });
            return response;
        }
    }
}
