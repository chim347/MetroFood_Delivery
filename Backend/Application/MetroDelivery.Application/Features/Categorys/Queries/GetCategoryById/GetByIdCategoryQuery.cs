using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Categorys.Queries.GetCategoryById
{
    public class GetByIdCategoryQuery : IRequest<CategoryResponse>
    {
        public string Id { get; set; }
    }

    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, CategoryResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public GetByIdCategoryQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<CategoryResponse> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var categoryExist = await _metroPickUpDbContext.Categories.Where(c => c.Id == Guid.Parse(request.Id)).SingleOrDefaultAsync();
            if (categoryExist == null) {
                throw new NotFoundException("category không tồn tồn tại!");
            }
            if (categoryExist.IsDelete == true) {
                throw new NotFoundException("category đã bị xóa!");
            }

            var data = _mapper.Map<CategoryResponse>(categoryExist);

            return data;
        }
    }
}
