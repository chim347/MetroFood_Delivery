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

namespace MetroDelivery.Application.Features.Categorys.Queries.GetAllCategory
{
    public class GetListCategoryQuery : IRequest<List<CategoryResponse>>
    {
    }

    public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, List<CategoryResponse>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetListCategoryQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<List<CategoryResponse>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            var categoryList = await _metroPickUpDbContext.Categories.Where(c => !c.IsDelete).ToListAsync();
            if(!categoryList.Any()) {
                throw new NotFoundException("Không có category nào hết");
            }

            var data = _mapper.Map<List<CategoryResponse>>(categoryList);

            return data;
        }
    }
}
