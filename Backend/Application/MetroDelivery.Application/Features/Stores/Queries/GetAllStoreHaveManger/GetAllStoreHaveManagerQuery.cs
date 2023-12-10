using AutoMapper;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Features.Manager.Queries;
using MetroDelivery.Application.Features.Staff.Queries;
using MetroDelivery.Domain.Entities;
using MetroDelivery.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Stores.Queries.GetAllStoreHaveManger
{
    public class GetAllStoreHaveManagerQuery : IRequest<List<StoreResponse>>
    {
    }

    public class GetAllStoreHaveManagerQueryHandler : IRequestHandler<GetAllStoreHaveManagerQuery, List<StoreResponse>>
    {
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public GetAllStoreHaveManagerQueryHandler(IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _metroPickUpDbContext = metroPickUpDbContext;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<List<StoreResponse>> Handle(GetAllStoreHaveManagerQuery request, CancellationToken cancellationToken)
        {
            var userIdsInStaffRole = _userManager.GetUsersInRoleAsync("Manager").Result.Select(user => user.Id);
            var storeList = await _metroPickUpDbContext.Store.Where(s => !s.IsDelete)
                                        .Select(s => new StoreResponse
                                        {
                                            StoreId = s.Id,
                                            StoreName = s.StoreName,
                                            StoreLocation = s.StoreLocation,
                                            StoreOpenTime = s.StoreOpenTime,
                                            StoreCloseTime = s.StoreCloseTime,

                                            ManagerInformation = _userManager.Users
                                                                .Where(user => userIdsInStaffRole.Contains(user.Id) && user.EmailConfirmed && user.StoreId == s.Id)
                                                                .Select(user => new ManagerInformation
                                                                {
                                                                    Id = user.Id,
                                                                    Email = user.Email,
                                                                    FirstName = user.FirstName,
                                                                    LastName = user.LastName,
                                                                    PhoneNumber = user.PhoneNumber,
                                                                    Address = user.Address,
                                                                    Birthday = user.Birthday,
                                                                    StoreId = s.Id,
                                                                    Created = user.Created,

                                                                })
                                                                .ToList()
                                        }).ToListAsync();

            return storeList;
        }
    }
}
