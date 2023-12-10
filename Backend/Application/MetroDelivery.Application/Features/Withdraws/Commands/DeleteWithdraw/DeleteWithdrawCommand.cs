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

namespace MetroDelivery.Application.Features.Withdraws.Commands.DeleteWithdraw
{
    public class DeleteWithdrawCommand : IRequest<MetroPickUpResponse>
    {
        public string Id { get; set; }
    }

    public class DeleteWithdrawCommandHandler : IRequestHandler<DeleteWithdrawCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public DeleteWithdrawCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(DeleteWithdrawCommand request, CancellationToken cancellationToken)
        {
            var withdrawExist = await _metroPickUpDbContext.WithDraw.Where(w => w.Id == Guid.Parse(request.Id)).SingleOrDefaultAsync();
            if (withdrawExist == null) {
                throw new NotFoundException("WithdraId không tồn tại");
            }
            if (withdrawExist.IsDelete == true) {
                throw new NotFoundException("WithdraId đã bị xóa!");
            }

            withdrawExist.IsDelete = true;
            _metroPickUpDbContext.WithDraw.Update(withdrawExist);
            await _metroPickUpDbContext.SaveChangesAsync();

            return new MetroPickUpResponse
            {
                Message = "Delete Successfully"
            };
        }
    }

}
