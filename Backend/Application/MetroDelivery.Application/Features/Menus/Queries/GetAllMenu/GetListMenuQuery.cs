using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Menus.Queries.GetAllMenu
{
    public class GetListMenuQuery : IRequest<List<MenuResponse>>
    {
    }

    public class GetListMenuQueryHandler : IRequestHandler<GetListMenuQuery, List<MenuResponse>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetListMenuQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<List<MenuResponse>> Handle(GetListMenuQuery request, CancellationToken cancellationToken)
        {
            var listMenu = await _metroPickUpDbContext.Menu.Where(m => !m.IsDelete).ToListAsync();

            var data = _mapper.Map<List<MenuResponse>>(listMenu);

            return data;
        }
    }
}
