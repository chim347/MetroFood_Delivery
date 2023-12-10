using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public DeleteCustomerCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var customerDelete = await _metroPickUpDbContext.ApplicationUsers.Where(c => c.Id == request.Id).SingleOrDefaultAsync();
            if (customerDelete == null) {
                throw new NotFoundException(nameof(customerDelete.Email), request.Id);
            }
            else if (customerDelete.EmailConfirmed == false) {
                throw new NotFoundException("The customer have been deleted");
            }


            // rmove database
            customerDelete.EmailConfirmed = false;
            _metroPickUpDbContext.ApplicationUsers.Update(customerDelete);
            await _metroPickUpDbContext.SaveChangesAsync();

            // return
            return new MetroPickUpResponse
            {
                Message = "Delete Customer Successfully"
            };
        }
    }
}
