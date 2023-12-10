using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Features.Stations.Queries;
using MetroDelivery.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Staff.Queries.GetAllStaff
{
    public class GetListStaffQuery : IRequest<List<StaffRole>>
    {

    }

    public class GetListStaffQueryHandler : IRequestHandler<GetListStaffQuery, List<StaffRole>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public GetListStaffQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<List<StaffRole>> Handle(GetListStaffQuery request, CancellationToken cancellationToken)
        {
            // Lấy danh sách UserId của những người dùng có vai trò "Staff"
            var userIdsInStaffRole = _userManager.GetUsersInRoleAsync("Staff").Result.Select(user => user.Id);

            // Lấy thông tin chi tiết về người dùng từ bảng AspNetUsers
            var staffUsers = await _userManager.Users
                .Where(user => userIdsInStaffRole.Contains(user.Id) && user.EmailConfirmed)
                .AsNoTracking()
                .Select(user => new StaffRole
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
                })
                .ToListAsync();

            return staffUsers;


        }
    }
}
