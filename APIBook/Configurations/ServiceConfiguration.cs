using Api.Domain.Contracts;
using Api.Infrastructure.Implement;
using Api.Services;
using APIBook.Services;
using ApiDomain.Base;
using ApiDomain.Contract;
using ApiInfrastructure.Base;
using ApiInfrastructure.Context;
using ApiInfrastructure.Implement;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;

namespace APIBook.Configurations
{
	public static class ServiceConfiguration
	{
		public static void AddServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddMemoryCache();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddHttpClient();
			services.AddAutoMapper(typeof(AutoMapperProfile));
			services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("ApplicationDBContext")));

			services.AddScoped<IUnitOfWork, UnitOfWork>();
			#region Repository
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserTokenRepository, UserTokenRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IPermissionRepository, PermissionRepository>();
			services.AddScoped<IJobRepository, JobRepository>();
			services.AddScoped<IStaffRepository, StaffRepository>();
			services.AddScoped<IAttachmentFolderRepository, AttachmentFolderRepository>();
			services.AddScoped<IAttachmentRepository, AttachmentRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
            #endregion

            #region Service
            services.AddScoped<ICacheService, CacheService>();
			services.AddScoped<IRoleService, RoleService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IAuthService, AuthService>();
			services.AddScoped<IPermissionService, PermissionService>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<IStaffService, StaffService>();
			services.AddScoped<IAttachmentFolderService, AttachmentFolderService>();
			services.AddScoped<IAttachmentService, AttachmentService>();
            services.AddScoped<IJobService, JobService>();
            #endregion


            services.AddAuthentication()
			.AddJwtBearer("ApiJwtScheme", options =>
			{
			options.RequireHttpsMetadata = false;
			options.SaveToken = true;
			options.TokenValidationParameters = new TokenValidationParameters()
			{
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero,
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidAudience = configuration["Jwt:Audience"],
				ValidIssuer = configuration["Jwt:Issuer"],
				IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]))
			};
			options.Events = new JwtBearerEvents
			{
				OnAuthenticationFailed = context =>
				{
					return Task.CompletedTask;
				},
				OnChallenge = context =>
				{
					return Task.CompletedTask;
				},
				OnForbidden = context =>
				{
					return Task.CompletedTask;
				},
				OnTokenValidated = async context =>
				{
					var endpoint = context.HttpContext.GetEndpoint();
                    var allowAnonymousAttr = endpoint?.Metadata.GetMetadata<AllowAnonymousAttribute>();
                    var authorizeAttr = endpoint?.Metadata.GetMetadata<AuthorizeAttribute>();

                    if (allowAnonymousAttr == null && authorizeAttr !=null)
					{
                        var authHeader = context.Request.Headers["Authorization"].ToString();
                        var authService = context.HttpContext.RequestServices.GetRequiredService<IAuthService>();
                        var isTokenExists = await authService.IsTokenExists(authHeader.Replace("Bearer", "").Trim());

                        if (!isTokenExists)
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            context.Response.Headers["WWW-Authenticate"] =
                                "Bearer error=\"invalid_token\", error_description=\"revoked\"";

                            context.Fail("Token is revoke");
                        }
                    }
                 
                },
			};
		});
				services.AddAuthorization(options =>
				{
					var policyBuilder = new AuthorizationPolicyBuilder(
						//"IdentityServerScheme",
						"ApiJwtScheme");
					policyBuilder =
						policyBuilder.RequireAuthenticatedUser();
					options.DefaultPolicy = policyBuilder.Build(); //dùng thằng jwt nào cũng được
				});
		}

	}
}
