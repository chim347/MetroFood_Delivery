using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
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

namespace MetroDelivery.Application.Features.Customers.Queries.GetByIdForAdmin
{
    public record GetByIdForAdminQuery(string id) : IRequest<CustomerRole>;

    public class GetByIdForAdminQueryhandler : IRequestHandler<GetByIdForAdminQuery, CustomerRole>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public GetByIdForAdminQueryhandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<CustomerRole> Handle(GetByIdForAdminQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.id);

            if (user != null && user.EmailConfirmed) {
                var isEndUser = await _userManager.IsInRoleAsync(user, "EndUser");
                var isManager = await _userManager.IsInRoleAsync(user, "Manager");
                var isStaff = await _userManager.IsInRoleAsync(user, "Staff");
                var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
                if (isEndUser) {
                    var customerRole = new CustomerRole
                    {
                        CustomerId = user.Id,
                        CustomerData = new CustomerInfo
                        {
                            Id = user.Id,
                            Email = user.Email,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            PhoneNumber = user.PhoneNumber,
                            Wallet = user.Wallet,
                            Address = user.Address,
                            Birthday = user.Birthday,
                            Created = user.Created,
                        },
                        RoleId = "CF531396-C1CD-427B-9D17-0383B7675394",
                        RoleData = new RoleData
                        {
                            Id = "CF531396-C1CD-427B-9D17-0383B7675394",  // Thay thế "YourRoleId" bằng Id thực tế của vai trò "Staff" trong bảng AspNetRoles
                            Name = "EndUser"      // Thay thế "Staff" bằng tên thực tế của vai trò "Staff" trong bảng AspNetRoles
                        }
                    };

                    return customerRole;
                }
                if (isManager) {
                    var staffRole = new CustomerRole
                    {
                        CustomerId = user.Id,
                        CustomerData = new CustomerInfo
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
                        RoleId = "04D67210-257D-4DD5-BAFC-13DDE8CA0DFE",
                        RoleData = new RoleData
                        {
                            Id = "04D67210-257D-4DD5-BAFC-13DDE8CA0DFE",  // Thay thế "YourRoleId" bằng Id thực tế của vai trò "Staff" trong bảng AspNetRoles
                            Name = "Manager"      // Thay thế "Staff" bằng tên thực tế của vai trò "Staff" trong bảng AspNetRoles
                        }
                    };

                    return staffRole;
                }
                if (isStaff) {
                    var staffRole = new CustomerRole
                    {
                        CustomerId = user.Id,
                        CustomerData = new CustomerInfo
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
                if (isAdmin) {
                    var staffRole = new CustomerRole
                    {
                        CustomerId = user.Id,
                        CustomerData = new CustomerInfo
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
                        RoleId = "AF5EB4AC-219A-4BC1-99FE-8C23876536EA",
                        RoleData = new RoleData
                        {
                            Id = "AF5EB4AC-219A-4BC1-99FE-8C23876536EA",  // Thay thế "YourRoleId" bằng Id thực tế của vai trò "Staff" trong bảng AspNetRoles
                            Name = "Admin"      // Thay thế "Staff" bằng tên thực tế của vai trò "Staff" trong bảng AspNetRoles
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
