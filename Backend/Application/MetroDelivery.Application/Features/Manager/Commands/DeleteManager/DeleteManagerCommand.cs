using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.CRUDResponse;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Manager.Commands.DeleteManager
{
    public class DeleteManagerCommand : IRequest<MetroPickUpResponse>
    {
        public string Id { get; set; }
    }

    public class DeleteManagerCommandHandler : IRequestHandler<DeleteManagerCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public DeleteManagerCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(DeleteManagerCommand request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var customerDelete = await _metroPickUpDbContext.ApplicationUsers.Where(c => c.Id == request.Id).SingleOrDefaultAsync();
            if (customerDelete == null) {
                throw new NotFoundException(nameof(customerDelete.Email), request.Id);
            }
            else if (customerDelete.EmailConfirmed == false) {
                throw new NotFoundException("The Manager have been deleted");
            }


            // rmove database
            customerDelete.EmailConfirmed = false;
            _metroPickUpDbContext.ApplicationUsers.Update(customerDelete);
            await _metroPickUpDbContext.SaveChangesAsync();

            // return
            return new MetroPickUpResponse
            {
                Message = "Delete Manager Successfully"
            };
        }
    }
}
