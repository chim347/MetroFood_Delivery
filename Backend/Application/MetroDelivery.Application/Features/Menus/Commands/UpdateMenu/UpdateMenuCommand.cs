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

namespace MetroDelivery.Application.Features.Menus.Commands.UpdateMenu
{
    public class UpdateMenuCommand : IRequest<MetroPickUpResponse>
    {
        public string Id { get; set; }
        /*public string MenuName { get; set; }*/ // tên menu là độc nhất nên 1 là xóa menu tạo lại, chứ ko đc update tên menu
        public TimeSpan StartTimeService { get; set; }
        public TimeSpan EndTimeService { get; set; }
    }

    public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public UpdateMenuCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            var menuExsit = await _metroPickUpDbContext.Menu.Where(m => m.Id == Guid.Parse(request.Id)).SingleOrDefaultAsync();
            if (menuExsit == null) {
                throw new NotFoundException("Menu này không tồn tại");
            }
            if (menuExsit.IsDelete == true) {
                throw new NotFoundException("Menu đã bị xóa rồi");
            }

            menuExsit.StartTimeService = request.StartTimeService;
            menuExsit.EndTimeService = request.EndTimeService;

            _metroPickUpDbContext.Menu.Update(menuExsit);
            await _metroPickUpDbContext.SaveChangesAsync();

            return new MetroPickUpResponse { 
                Message = "Update Successfully"
            };
        }
    }
}
