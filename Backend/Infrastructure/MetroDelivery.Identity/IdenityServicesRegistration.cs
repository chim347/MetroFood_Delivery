using MetroDelivery.Application.Common.Interface;
using MetroDelivery.Application.Contracts.Identity;
using MetroDelivery.Application.Contracts.Persistance;
using MetroDelivery.Application.Models.Identity;
using MetroDelivery.Domain.IdentityModels;
using MetroDelivery.Identity.DbContexts;
using MetroDelivery.Identity.DbContexts.Interceptor;
using MetroDelivery.Identity.Repositories;
using MetroDelivery.Identity.Services;
using MetroDelivery.Identity.Services.VnPay;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Identity
{
    public static class IdenityServicesRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddDbContext<MetroPickupIdentityDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("MetroDeliveryConnectionString"),
                    builder => builder.MigrationsAssembly(typeof(MetroPickupIdentityDbContext).Assembly.FullName));
            });

            services.AddScoped<IMetroPickUpDbContext>(provider => provider.GetRequiredService<MetroPickupIdentityDbContext>());
            

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<MetroPickupIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IDateTime, DateTimeService>();


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(o =>
            {
                o.SaveToken = true;
                o.RequireHttpsMetadata = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                {
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    BearerFormat = "JwtSettings",
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Name = "Authorization",
                    Description = "Insert JWT Token"
                });
                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        new string[]{}
                    }
                });
            });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    //.AddAuthenticationSchemes(
                    //    CookieAuthenticationDefaults.AuthenticationScheme‌​,
                    //    GoogleDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();

                options.AddPolicy("Admin", policy => policy
                    .Combine(options.DefaultPolicy)
                    .RequireRole("Admin")
                .Build());
                options.AddPolicy("Staff", policy => policy
                        .Combine(options.DefaultPolicy)
                        .RequireRole("Staff")
                        .Build());
                options.AddPolicy("User", policy => policy
                   .Combine(options.DefaultPolicy)
                   .RequireRole("User")
                   .Build());
                options.AddPolicy("AdminOrStaff", policy => policy
            .Combine(options.DefaultPolicy)
            .RequireRole("Admin", "Staff")
            .Build());

            });

            //Vn Pay
            /*configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            services.AddSingleton(configuration);*/

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            /*services.AddScoped<ICustomerRepository, CustomerRepository>();*/
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IMenuProductRepository, MenuProductRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IRouteStationRepository, RouteStationRepository>();
            services.AddScoped<IStationRepository, StationRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<ITripRepository, TripRepository>();
            services.AddScoped<IWithDrawRepository, WithDrawRepository>();
            services.AddScoped<IVnPayService, VnPayService>();

            return services;
        }
    }
}
