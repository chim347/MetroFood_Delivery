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

namespace MetroDelivery.Application.Features.Menus.Commands.DeleteMenu
{
    public class DeleteMenuCommand : IRequest<MetroPickUpResponse>
    {
        public string Id { get; set; }
    }

    public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public DeleteMenuCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            var menuExsit = await _metroPickUpDbContext.Menu.Where(m => m.Id == Guid.Parse(request.Id)).SingleOrDefaultAsync();
            if(menuExsit == null) {
                throw new NotFoundException("Menu này không tồn tại");
            }
            if (menuExsit.IsDelete == true) {
                throw new NotFoundException("Menu đã bị xóa rồi");
            }

            menuExsit.IsDelete = true;
            _metroPickUpDbContext.Menu.Update(menuExsit);
            await _metroPickUpDbContext.SaveChangesAsync();

            return new MetroPickUpResponse
            {
                Message = "Delete Successfully"
            };
        }
    }
}
