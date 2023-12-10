using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Features.Customers;
using MetroDelivery.Application.Features.Stations.Queries;
using MetroDelivery.Domain.Entities;
using MetroDelivery.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Staff.Queries.GetByIdStaff
{
    public record GetByIdStaffQuery (string id) : IRequest<StaffRole>;

    public class GetByIdStaffQueryHandler : IRequestHandler<GetByIdStaffQuery, StaffRole>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public GetByIdStaffQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<StaffRole> Handle(GetByIdStaffQuery request, CancellationToken cancellationToken)
        {
            //add to datbase 
            var user = await _userManager.FindByIdAsync(request.id);

            if (user != null && user.EmailConfirmed) {
                var isStaff = await _userManager.IsInRoleAsync(user, "Staff");
                if (isStaff) {
                    var staffRole = new StaffRole
                    {
                        StaffId = user.Id,
                        StaffData = new StaffData
                        {
                            Id = user.Id,
                            Email = user.Email,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            PhoneNumber = user.PhoneNumber,
                            Address = user.Address,
                            Birthday = user.Birthday,
                            StoreId = user.StoreId,
                            StoreData = _mapper.Map<StoreData>(_metroPickUpDbContext.Store.Where(s => s.Id == user.StoreId).SingleOrDefault()),
                            Created = user.Created,
                        },
                        RoleId = "647D9649-F5A2-4F24-808F-6FC326EC2AA3",
                        RoleData = new RoleData
                        {
                            Id = "647D9649-F5A2-4F24-808F-6FC326EC2AA3",  // Thay thế "YourRoleId" bằng Id thực tế của vai trò "Staff" trong bảng AspNetRoles
                            Name = "Staff"      // Thay thế "Staff" bằng tên thực tế của vai trò "Staff" trong bảng AspNetRoles
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
