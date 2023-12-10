using AutoMapper;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Contracts.Identity;
using MetroDelivery.Application.Features.Stations.Queries;
using MetroDelivery.Application.Models.Identity;
using MetroDelivery.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Collections.Concurrent;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MetroDelivery.Identity.Services
{
    public class AuthService : IAuthService
    {
        private static readonly ConcurrentDictionary<string, Guid> _refreshTokens = new ConcurrentDictionary<string, Guid>();
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _siginInManager;
        private readonly JwtSettings _jwtSettings;
        private readonly IConfiguration _configuration;
        private readonly IMetroPickUpDbContext _metroPickUpDbContext;
        private readonly IMapper _mapper;

        public AuthService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> siginInManager,
            IOptions<JwtSettings> jwtSettings,
            IConfiguration configuration, IMetroPickUpDbContext metroPickUpDbContext, IMapper mapper)
        {
            this._userManager = userManager;
            this._siginInManager = siginInManager;
            this._jwtSettings = jwtSettings.Value;
            this._configuration = configuration;
            this._metroPickUpDbContext = metroPickUpDbContext;
            this._mapper = mapper;
        }
        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) {
                throw new NotFoundException($"User with {request.Email} not found.", request.Email);
            }

            var result = await _siginInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded == false) {
                throw new BadRequestException($"Credentials for '{request.Email} aren't valid '.");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
            var isManager = await _userManager.IsInRoleAsync(user, "Manager");
            var isStaff = await _userManager.IsInRoleAsync(user, "Staff");
            AuthResponse response = new AuthResponse();
            if (isManager || isStaff) {
                response.Id = user.Id;
                response.AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                response.Email = user.Email;
                response.UserName = user.UserName;
                response.RefreshToken = GenerateRefreshToken(user.UserName).ToString("D");
                response.Expires = DateTime.Now.AddHours(7).AddMinutes(_jwtSettings.DurationInMinutes);
                /*response.Expires = DateTime.Now.AddSeconds(_jwtSettings.DurationInMinutes);*/
                //storeData
                response.StoreId = user.StoreId;
                var storeExist = await _metroPickUpDbContext.Store.Where(x => x.Id == response.StoreId).SingleOrDefaultAsync();
                response.StoreData = _mapper.Map<StoreData>(storeExist);

                return response;
            }

            response.Id = user.Id;
            response.AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.UserName = user.UserName;
            response.RefreshToken = GenerateRefreshToken(user.UserName).ToString("D");
            response.Expires = DateTime.Now.AddHours(7).AddMinutes(_jwtSettings.DurationInMinutes);
           /* response.Expires = DateTime.Now.AddSeconds(_jwtSettings.DurationInMinutes);*/

            return response;

        }

        public async Task<AuthenticationResultResponse> Refresh(AuthenticationResult request)
        {

            if (!IsValid(request, out string userName)) {
                return null;
            }
            var user = await _userManager.FindByNameAsync(userName);
            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var response = new AuthenticationResultResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                StoreId = user.StoreId,

                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                RefreshToken = GenerateRefreshToken(user.UserName).ToString("D"),
                /*Expires = DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes)*/
                Expires = DateTime.Now.AddHours(7).AddMinutes(_jwtSettings.DurationInMinutes)
            };

            return response;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var userExist = await _userManager.FindByEmailAsync(request.Email);
            if (userExist != null) {
                throw new BadRequestException($"Email {request.Email} is Existed!!");
            }
            var user = new ApplicationUser
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true,
                Created = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded) {
                await _userManager.AddToRoleAsync(user, "EndUser");
                return new RegistrationResponse() { UserId = user.Id };
            }
            else {
                StringBuilder str = new StringBuilder();
                foreach (var err in result.Errors) {
                    str.AppendFormat("{0}\n", err.Description);
                }
                throw new BadRequestException($"{str}");
            }
        }

        private bool IsValid(AuthenticationResult authResult, out string userName)
        {
            userName = string.Empty;
            ClaimsPrincipal principal = GetPrincipalFromExpiredToken(authResult.AccessToken);
            if (principal is null) {
                throw new UnauthorizedAccessException("No principal");
            }
            userName = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userName)) {
                throw new UnauthorizedAccessException("No user name");
            }
            if (!Guid.TryParse(authResult.RefreshToken, out Guid givenRefreshToken)) {
                throw new UnauthorizedAccessException("Refresh token malformed");
            }
            if (!_refreshTokens.TryGetValue(userName, out Guid currentRefreshToken)) {
                throw new UnauthorizedAccessException("No valid refresh token in system");
            }

            if (currentRefreshToken != givenRefreshToken) {
                throw new UnauthorizedAccessException("Invalid refesh token");
            }
            return true;
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string accessToken)
        {
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidIssuer = _configuration["JwtSettings:Issuer"],
                ValidAudience = _configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"])),
                NameClaimType = JwtRegisteredClaimNames.Sub,
                RoleClaimType = ClaimTypes.Role,
            };

            JwtSecurityTokenHandler token = new JwtSecurityTokenHandler();
            ClaimsPrincipal principal = token.ValidateToken(accessToken, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCulture)) {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(q => new Claim("role", q)).ToList();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var sigingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(7).AddMinutes(_jwtSettings.DurationInMinutes),
                /*expires: DateTime.Now.AddSeconds(_jwtSettings.DurationInMinutes),*/
                signingCredentials: sigingCredentials);
            return jwtSecurityToken;
        }

        /*private async Task<AuthenticationResult> GetAccessToken(ApplicationUser user)
        {

            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(q => new Claim("role", q)).ToList();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var sigingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var expiry = DateTime.UtcNow.AddSeconds(_jwtSettings.DurationInMinutes);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: expiry,
                signingCredentials: sigingCredentials);
            return new AuthenticationResult()
            {
                AccessToken = (new JwtSecurityTokenHandler()).WriteToken(jwtSecurityToken),
                RefreshToken = GenerateRefreshToken(user.UserName).ToString("D"),
                Expires = expiry,
            };
        }*/

        private Guid GenerateRefreshToken(string userName)
        {
            Guid newToken = _refreshTokens.AddOrUpdate(userName, u => Guid.NewGuid(), (u, o) => Guid.NewGuid());
            return newToken;
        }


    }
}
