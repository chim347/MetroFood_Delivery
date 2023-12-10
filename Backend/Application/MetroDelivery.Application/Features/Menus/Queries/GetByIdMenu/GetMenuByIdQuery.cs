using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Menus.Queries.GetByIdMenu
{
    public class GetMenuByIdQuery : IRequest<MenuResponse>
    {
        public string Id { get; set; }
    }

    public class GetMenuByIdQueryHandler : IRequestHandler<GetMenuByIdQuery, MenuResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetMenuByIdQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MenuResponse> Handle(GetMenuByIdQuery request, CancellationToken cancellationToken)
        {
            var menuExsit = await _metroPickUpDbContext.Menu.Where(m => m.Id == Guid.Parse(request.Id)).SingleOrDefaultAsync();
            if (menuExsit == null) {
                throw new NotFoundException("Menu này không tồn tại");
            }
            if (menuExsit.IsDelete == true) {
                throw new NotFoundException("Menu đã bị xóa rồi");
            }

            var data = _mapper.Map<MenuResponse>(menuExsit);

            return data;
        }
    }
}
