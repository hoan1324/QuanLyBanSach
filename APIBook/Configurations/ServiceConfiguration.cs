using APIBook.Services;
using ApiDomain.Base;
using ApiDomain.Contract;
using ApiInfrastructure.Base;
using ApiInfrastructure.Context;
using ApiInfrastructure.Implement;
using Microsoft.EntityFrameworkCore;

namespace APIBook.Configurations
{
	public static class ServiceConfiguration
	{
		public static void AddServices(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddAutoMapper(typeof(AutoMapperProfile));
			services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("ApplicationDBContext")));
			
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			#region Repository
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped<IJobRepository, JobRepository>();
			services.AddScoped<IStaffRepository, StaffRepository>();
			#endregion

			#region Service
			services.AddScoped<IJobService, JobService>();
			services.AddScoped<IStaffService, StaffService>();
			#endregion
		}

	}
}
