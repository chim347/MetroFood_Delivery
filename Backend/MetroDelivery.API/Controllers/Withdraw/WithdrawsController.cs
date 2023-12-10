using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Features.Withdraws.Commands.CreateWithdraw;
using MetroDelivery.Application.Features.Withdraws.Commands.DeleteWithdraw;
using MetroDelivery.Application.Features.Withdraws.Commands.UpdateWithdraw;
using MetroDelivery.Application.Features.Withdraws.Queries;
using MetroDelivery.Application.Features.Withdraws.Queries.GetAllWithdraw;
using MetroDelivery.Application.Features.Withdraws.Queries.GetByIdWithdraw;
using MetroDelivery.Application.Features.Withdraws.Queries.GetByUserId;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MetroDelivery.API.Controllers.Withdraw
{
    [Route("api/v1/withdraws")]
    [ApiController]
    public class WithdrawsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WithdrawsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<WithdrawResponse>> GetAll()
        {
            var response = await _mediator.Send(new GetListWithdrawQuery());
            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<WithdrawResponse> Get(string id)
        {
            var response = await _mediator.Send(new GetByIdWithdrawQuery()
            {
                Id = id
            });
            return response;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Create([FromBody] CreateWithdrawCommand request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtAction(nameof(GetAll), new { id = response });
        }
        [HttpGet]
        [Route("customers/{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> GetByUserId(string id)
        {
            var response = await _mediator.Send(new GetByUserIdCommand
            {
                UserId = id
            });
            return CreatedAtAction(nameof(GetAll), new { data = response });
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<MetroPickUpResponse> Update(UpdateWithdrawCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<MetroPickUpResponse> Delete([FromQuery] DeleteWithdrawCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
    }
}
