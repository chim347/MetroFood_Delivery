using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Contracts.Logging;
using MetroDelivery.Application.Contracts.Persistance;
using MetroDelivery.Application.Features.Staff.Queries;
using MetroDelivery.Application.Models.Identity;
using MetroDelivery.Domain.Entities;
using MetroDelivery.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetListCustomerQueryHandler : IRequestHandler<GetListCustomerQuery, List<CustomerRole>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public GetListCustomerQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<List<CustomerRole>> Handle(GetListCustomerQuery request, CancellationToken cancellationToken)
        {
            // Lấy danh sách UserId của những người dùng có vai trò "EndUser"
            var userIdsInCustomerRole = _userManager.GetUsersInRoleAsync("EndUser").Result.Select(user => user.Id);

            // Lấy thông tin chi tiết về người dùng từ bảng AspNetUsers
            var EndUsers = await _userManager.Users
                .Where(user => userIdsInCustomerRole.Contains(user.Id) && user.EmailConfirmed)
                .Select(user => new CustomerRole
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
                                Id = "CF531396-C1CD-427B-9D17-0383B7675394",  // Thay thế "YourRoleId" bằng Id thực tế của vai trò "EndUser" trong bảng AspNetRoles
                                Name = "EndUser"      // Thay thế "Staff" bằng tên thực tế của vai trò "EndUser" trong bảng AspNetRoles
                            }
                        })
                        .ToListAsync();

            return EndUsers;
        }
    }
}
