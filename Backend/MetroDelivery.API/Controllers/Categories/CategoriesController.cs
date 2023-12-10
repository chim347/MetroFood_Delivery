using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Features.Categorys.Commands.CreateCategory;
using MetroDelivery.Application.Features.Categorys.Commands.DeleteCategory;
using MetroDelivery.Application.Features.Categorys.Commands.UpdateCategory;
using MetroDelivery.Application.Features.Categorys.Queries;
using MetroDelivery.Application.Features.Categorys.Queries.GetAllCategory;
using MetroDelivery.Application.Features.Categorys.Queries.GetCategoryById;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MetroDelivery.API.Controllers.Categories
{
    [Route("api/v1/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<CategoryResponse>> GetAll()
        {
            var response = await _mediator.Send(new GetListCategoryQuery());  
            return response;
        }

        [HttpGet]
        [Route("{categoryid}")]
        public async Task<ActionResult<CategoryResponse>> GetUserById(string categoryid)
        {
            var request = new GetByIdCategoryQuery { Id = categoryid };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Create([FromBody] CreateCategoryCommand request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtAction(nameof(GetAll), new { id = response });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<MetroPickUpResponse> Update([FromBody]UpdateCategoryCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpDelete]
        [Route("{categoryid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<MetroPickUpResponse> Delete(string categoryid)
        {
            var request = new DeleteCategoryCommand { Id = categoryid };
            var response = await _mediator.Send(request);
            return response;
        }
    }
}
