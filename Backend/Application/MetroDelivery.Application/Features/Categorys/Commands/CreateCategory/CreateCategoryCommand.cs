using MediatR;
using MetroDelivery.Application.Features.Categorys.Commands.UpdateCategory;
using MetroDelivery.Application.Features.Menus.Commands.CreateMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Categorys.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public string CategoryName { get; set; }
    }
}
