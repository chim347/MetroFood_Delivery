using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Contracts.Persistance;
using MetroDelivery.Application.Features.Manager.Queries;
using MetroDelivery.Application.Features.Staff.Queries;
using MetroDelivery.Application.Features.Stations.Queries;
using MetroDelivery.Domain.Entities;
using MetroDelivery.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MetroDelivery.Application.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerRole>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public GetCustomerByIdQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<CustomerRole> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.id);

            if (user != null && user.EmailConfirmed) {
                var isEndUser = await _userManager.IsInRoleAsync(user, "EndUser");
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
            }

            // Nếu không tìm thấy hoặc Email chưa được xác nhận, trả về null hoặc thực hiện xử lý phù hợp.
            throw new NotFoundException("không tìm thấy nhân vật này");
        }
    }
}
