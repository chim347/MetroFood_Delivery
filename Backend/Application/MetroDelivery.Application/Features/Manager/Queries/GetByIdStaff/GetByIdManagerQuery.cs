using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Features.Customers;
using MetroDelivery.Application.Features.Manager.Queries;
using MetroDelivery.Application.Features.Staff.Queries;
using MetroDelivery.Application.Features.Stations.Queries;
using MetroDelivery.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Manager.Queries.GetByIdStaff
{
    public record GetByIdManagerQuery(string id) : IRequest<ManagerRole>;

    public class GetByIdManagerQueryHandler : IRequestHandler<GetByIdManagerQuery, ManagerRole>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public GetByIdManagerQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<ManagerRole> Handle(GetByIdManagerQuery request, CancellationToken cancellationToken)
        {
            //add to datbase 
            var user = await _userManager.FindByIdAsync(request.id);

            if (user != null && user.EmailConfirmed) {
                var isStaff = await _userManager.IsInRoleAsync(user, "Manager");
                if (isStaff) {
                    var staffRole = new ManagerRole
                    {
                        ManagerId = user.Id,
                        MangerData = new MangerData
                        {
                            Id = user.Id,
                            Email = user.Email,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            PhoneNumber = user.PhoneNumber,
                            Address = user.Address,
                            Birthday = user.Birthday,
                            StoreId = user.StoreId,
                            Created = user.Created,
                            StoreData = _mapper.Map<StoreData>(_metroPickUpDbContext.Store.Where(s => s.Id == user.StoreId).SingleOrDefault()),
                        },
                        RoleId = "04D67210-257D-4DD5-BAFC-13DDE8CA0DFE",
                        RoleData = new RoleData
                        {
                            Id = "04D67210-257D-4DD5-BAFC-13DDE8CA0DFE",  // Thay thế "YourRoleId" bằng Id thực tế của vai trò "Staff" trong bảng AspNetRoles
                            Name = "Manager"      // Thay thế "Staff" bằng tên thực tế của vai trò "Staff" trong bảng AspNetRoles
                        }
                    };

                    return staffRole;
                }
            }
            // Nếu không tìm thấy hoặc Email chưa được xác nhận, trả về null hoặc thực hiện xử lý phù hợp.
            throw new NotFoundException("không tìm thấy nhân vật này");
        }
    }

}
