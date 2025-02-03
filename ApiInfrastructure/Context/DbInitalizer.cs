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
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new ApplicationDBContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDBContext>>()))
			{
				context.Database.Migrate();

				// Kiểm tra xem đã có user nào chưa, nếu có thì không làm gì nữa
				if (context.Users.Any())
				{
					return;
				}

				// Thêm role nếu chưa có
				var roleID = Guid.NewGuid();
				if (!context.Roles.Any(r => r.Code == "admin"))
				{
					context.Roles.Add(new Role
					{
						Id = roleID,
						Name = "Quản trị viên",
						Code = "admin",
						IsAdmin = true,
					});
					context.SaveChanges();
				}
				

				// Tạo user admin nếu chưa có
				if (!context.Users.Any(u => u.UserName == "admin"))
				{
					context.Users.Add(new User
					{
						UserName = "admin",
						Password = "01032004", // Hash mật khẩu
						DateOfBirth = DateTime.Now,
						PhoneNumber = "0348966964",
						Email = "hoan3397@gmail.com",
						Gender = 0,
						Status = 0,
						RoleID = roleID
					});
				}

				// Thêm các thư mục nếu chưa có
				if (!context.AttachmentFolders.Any())
				{
					List<AttachmentFolder> attachmentFolders = new List<AttachmentFolder>()
			{
				new AttachmentFolder{Id=Guid.NewGuid(),Name="Tài liệu",Description="Thư mục chứa các tài liệu",ParentId=null,Status=0,CreatedBy=null},
				new AttachmentFolder{Id=Guid.NewGuid(),Name="Ảnh",Description="Thư mục chứa các ảnh",ParentId=null,Status=0,CreatedBy=null},
				new AttachmentFolder{Id=Guid.NewGuid(),Name="Tệp",Description="Thư mục chứa các tệp",ParentId=null,Status=0,CreatedBy=null}
			};
					context.AttachmentFolders.AddRange(attachmentFolders);
				}

				// Lưu toàn bộ thay đổi một lần duy nhất
				context.SaveChanges();

			}



		}
	}
}

