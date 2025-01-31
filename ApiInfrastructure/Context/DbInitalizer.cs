using ApiDomain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiInfrastructure.Context
{
	public class DbInitalizer
	{
		public static void Initialize(IServiceProvider serviceProvider) {
			using (var context =new ApplicationDBContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDBContext>>()))
			{
				context.Database.Migrate();
				if (context.Users.Any()) { 
				return;
				}
				var roleID=Guid.NewGuid();
				context.Roles.Add(new Role
				{
					Id=roleID,
					Name = "Quản trị viên",
					Code = "admin",
					IsAdmin = true,
				});
				context.SaveChanges();
				context.Users.Add(new User
				{
					UserName="admin",
					Password="admin",
					DateOfBirth=DateTime.Now,
					PhoneNumber="0348966964",
					Email="hoan3397@gmail.com",
					Gender = 0,
					Status=0,
					RoleID=roleID

				});
				context.SaveChanges();
				

			}



		}
	}
}

