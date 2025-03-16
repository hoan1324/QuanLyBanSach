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
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IPermissionRepository, PermissionRepository>();
			services.AddScoped<IJobRepository, JobRepository>();
			services.AddScoped<IStaffRepository, StaffRepository>();
			services.AddScoped<IAttachmentFolderRepository, AttachmentFolderRepository>();
			services.AddScoped<IAttachmentRepository, AttachmentRepository>();
			#endregion

			#region Service
			services.AddScoped<ICacheService, CacheService>();
			services.AddScoped<IRoleService, RoleService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IAuthService, AuthService>();
			services.AddScoped<IPermissionService, PermissionService>();
			services.AddScoped<IJobService, JobService>();
			services.AddScoped<IStaffService, StaffService>();
			services.AddScoped<IAttachmentFolderService, AttachmentFolderService>();
			services.AddScoped<IAttachmentService, AttachmentService>();


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
				OnTokenValidated = context =>
				{
					return Task.CompletedTask;
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
			#endregion
		}

	}
}
