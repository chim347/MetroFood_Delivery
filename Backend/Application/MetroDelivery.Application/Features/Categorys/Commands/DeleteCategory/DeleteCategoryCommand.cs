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

namespace MetroDelivery.Application.Features.Categorys.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<MetroPickUpResponse>
    {
        public string Id { get; set; }
    }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, MetroPickUpResponse>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        public DeleteCategoryCommandHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
        }

        public async Task<MetroPickUpResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryExist = await _metroPickUpDbContext.Categories.Where(c => c.Id == Guid.Parse(request.Id)).SingleOrDefaultAsync();
            if(categoryExist == null) {
                throw new NotFoundException("category không tồn tại!");
            }
            if (categoryExist.IsDelete == true) {
                throw new NotFoundException("category đã bị xóa!");
            }

            categoryExist.IsDelete = true;
            _metroPickUpDbContext.Categories.Update(categoryExist);
            await _metroPickUpDbContext.SaveChangesAsync();

            return new MetroPickUpResponse
            {
                Message = "Delete Successfully"
            };
        }
    }
}
