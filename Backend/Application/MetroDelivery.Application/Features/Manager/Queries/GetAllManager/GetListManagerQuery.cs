using AutoMapper;
using MediatR;
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

namespace MetroDelivery.Application.Features.Manager.Queries.GetAllManager
{
    public class GetListManagerQuery : IRequest<List<ManagerRole>>
    {

    }

    public class GetListManagerQueryHandler : IRequestHandler<GetListManagerQuery, List<ManagerRole>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public GetListManagerQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<List<ManagerRole>> Handle(GetListManagerQuery request, CancellationToken cancellationToken)
        {
            // Lấy danh sách UserId của những người dùng có vai trò "Manager"
            var userIdsInStaffRole = _userManager.GetUsersInRoleAsync("Manager").Result.Select(user => user.Id);

            // Lấy thông tin chi tiết về người dùng từ bảng AspNetUsers
            var staffUsers = await _userManager.Users
                .Where(user => userIdsInStaffRole.Contains(user.Id) && user.EmailConfirmed)
                .Select(user => new ManagerRole
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
                })
                .ToListAsync();

            return staffUsers;


        }
    }
}
