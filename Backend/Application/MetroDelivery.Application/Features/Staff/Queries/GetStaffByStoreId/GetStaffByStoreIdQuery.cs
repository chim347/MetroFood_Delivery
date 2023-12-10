using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
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

namespace MetroDelivery.Application.Features.Staff.Queries.GetStaffByStoreId
{
    public class GetStaffByStoreIdQuery : IRequest<List<StaffRole>>
    {
        public string StoreId { get; set; }
    }

    public class GetStaffByStoreIdQueryHandler : IRequestHandler<GetStaffByStoreIdQuery, List<StaffRole>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public GetStaffByStoreIdQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<List<StaffRole>> Handle(GetStaffByStoreIdQuery request, CancellationToken cancellationToken)
        {
            //add to datbase 
            var user = await _metroPickUpDbContext.ApplicationUsers.Where(a => a.StoreId == Guid.Parse(request.StoreId)).ToListAsync();

            var staffRoles = new List<StaffRole>();
            foreach (var users in user) {
                if (users != null && users.EmailConfirmed) {
                    var isStaff = await _userManager.IsInRoleAsync(users, "Staff");
                    if (isStaff) {
                        var staffRole = new StaffRole
                        {
                            StaffId = users.Id,
                            StaffData = new StaffData
                            {
                                Id = users.Id,
                                Email = users.Email,
                                FirstName = users.FirstName,
                                LastName = users.LastName,
                                PhoneNumber = users.PhoneNumber,
                                Address = users.Address,
                                Birthday = users.Birthday,
                                StoreId = users.StoreId,
                                StoreData = GetStoreData(users.StoreId),
                                Created = users.Created,
                            },
                            RoleId = "647D9649-F5A2-4F24-808F-6FC326EC2AA3",
                            RoleData = new RoleData
                            {
                                Id = "647D9649-F5A2-4F24-808F-6FC326EC2AA3",  // Thay thế "YourRoleId" bằng Id thực tế của vai trò "Staff" trong bảng AspNetRoles
                                Name = "Staff"      // Thay thế "Staff" bằng tên thực tế của vai trò "Staff" trong bảng AspNetRoles
                            }
                        };

                        staffRoles.Add(staffRole);
                    }
                }
            }
            if (staffRoles.Count > 0) {
                return staffRoles;
            }

            // Nếu không tìm thấy hoặc Email chưa được xác nhận, trả về null hoặc thực hiện xử lý phù hợp.
            return staffRoles;
            /*throw new NotFoundException("Không tìm thấy nhân viên có vai trò 'Staff'");*/
        }
        private StoreData GetStoreData(Guid? id)
        {
            var storeExist = _metroPickUpDbContext.Store.Where(s => s.Id == id).SingleOrDefault();
            var data = _mapper.Map<StoreData>(storeExist);
            return data;
        }
    }
}
