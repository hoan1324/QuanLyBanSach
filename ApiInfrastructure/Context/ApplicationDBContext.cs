using ApiDomain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiInfrastructure.Context
{
	public class ApplicationDBContext : DbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
		{

		}
		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Permission> Permissions { get; set; }
		public DbSet<UserPermission> UserPermissions { get; set; }
		public DbSet<PermissionRole> PermissionRoles { get; set; }
		public DbSet<ActionLog> ActionLogs { get; set; }
		public DbSet<Banner> Banners { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<BookImage> BookImages { get; set; }
		public DbSet<BookRating> BookRatings { get; set; }
		public DbSet<BookReview> BookReviews { get; set; }
		public DbSet<BookGenres> BookGenres { get; set; }
		public DbSet<Genres> Genres { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<Combo> Combos { get; set; }
		public DbSet<ComboBook> ComboBooks { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<IssuingUnit> IssuingUnits { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<Menu> Menus { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<Purchase> Purchases { get; set; }
		public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
		public DbSet<QuestionAndAnswer> QuestionsAndAnswers { get; set; }
		public DbSet<Shipping> Shippings { get; set; }
		public DbSet<ShoppingCart> ShoppingCarts { get; set; }
		public DbSet<Staff> Staffs { get; set; }
		public DbSet<SystemConfig> SystemConfigs { get; set; }
		public DbSet<Warehouse> Warehouses { get; set; }
		public DbSet<Attachment> Attachments { get; set; }
		public DbSet<AttachmentFolder> AttachmentFolders { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var user = modelBuilder.Entity<User>();
			user.ToTable("Users");
			user.Property(n => n.UserName).IsRequired().HasColumnType("nvarchar(200) COLLATE Latin1_General_CI_AI");
			user.Property(n => n.Password).IsRequired().HasMaxLength(200).IsUnicode(true);
			user.Property(n => n.PhoneNumber).IsRequired().HasMaxLength(15).IsUnicode(false);
			user.Property(n => n.Email).IsRequired().HasMaxLength(200).IsUnicode(false);
			user.Property(n => n.Gender).IsRequired().HasDefaultValue(0);
			user.Property(n => n.Status).HasDefaultValue(0);
			user.Property(n => n.CreateDate).HasDefaultValue(DateTime.Now);
			user.HasOne(n => n.Role).WithMany(n => n.Users).HasForeignKey(n => n.RoleID);
			user.HasMany(n => n.UserPermissions).WithOne(n => n.User);
			user.HasMany(n => n.BookRatings).WithOne(n => n.User);
			user.HasMany(n => n.ShoppingCarts).WithOne(n => n.User);
			user.HasMany(n => n.Comments).WithOne(n => n.User);


			var role = modelBuilder.Entity<Role>();
			role.ToTable("Roles");
			role.Property(n => n.Name).IsRequired().HasColumnType("nvarchar(200) COLLATE Latin1_General_CI_AI");
			role.Property(n => n.Code).IsRequired().HasMaxLength(100).IsUnicode(false);
			role.Property(n => n.Description).HasColumnType("nvarchar(500)");
			role.Property(n => n.CreateDate).HasDefaultValue(DateTime.Now);
			role.Property(n => n.IsAdmin).HasDefaultValue(false);
			role.HasMany(n => n.Users).WithOne(n => n.Role);
			role.HasMany(n => n.Permissions).WithOne(n => n.Role);

			var permission = modelBuilder.Entity<Permission>();
			permission.ToTable("Permission");
			permission.Property(n => n.Name).IsRequired().HasColumnType("nvarchar(200) COLLATE Latin1_General_CI_AI");
			permission.Property(n => n.Code).IsRequired().HasMaxLength(100).IsUnicode(false);
			permission.Property(n=>n.CreatedDate).HasDefaultValue(DateTime.Now);
			permission.Property(n => n.Status).HasDefaultValue(0);
			permission.HasMany(n => n.UserPermissions).WithOne(n => n.Permission);
			permission.HasMany(n => n.PermissionRoles).WithOne(n => n.Permission);

			var folder = modelBuilder.Entity<AttachmentFolder>();
			folder.ToTable("AttachmentFolders");
			folder.Property(n => n.CreatedDate).HasDefaultValue(DateTime.Now);
			folder.Property(n => n.Name).HasMaxLength(300).IsUnicode(true).HasColumnType("nvarchar(300) COLLATE Latin1_General_CI_AI");
			folder.Property(n => n.Description).HasMaxLength(1000).IsUnicode(true);
			folder.Property(n => n.Status).HasDefaultValue(0);
			folder.HasMany(n => n.Attachments).WithOne(n => n.AttachmentFolder).HasForeignKey(n => n.AttachmentFolderId);

			var attachment = modelBuilder.Entity<Attachment>();
			attachment.ToTable("Attachments");
			attachment.Property(n => n.Name).HasMaxLength(300).IsUnicode(true).HasColumnType("nvarchar(300) COLLATE Latin1_General_CI_AI");
			attachment.Property(n => n.CreatedDate).HasDefaultValue(DateTime.Now);
			attachment.HasOne(n => n.AttachmentFolder).WithMany(n => n.Attachments).HasForeignKey(n => n.AttachmentFolderId);
			
			var userPermission = modelBuilder.Entity<UserPermission>();
			userPermission.ToTable("UserPermission");
			userPermission.HasKey(n => new { n.UserID, n.PermissionID });
			userPermission.HasOne(n => n.Permission).WithMany(n => n.UserPermissions).HasForeignKey(n => n.PermissionID);
			userPermission.HasOne(n => n.User).WithMany(n => n.UserPermissions).HasForeignKey(n => n.UserID);

			var permissionRole = modelBuilder.Entity<PermissionRole>();
			permissionRole.ToTable("PermissionRole");
			permissionRole.HasKey(n => new { n.RoleID, n.PermissionID });
			permissionRole.HasOne(n => n.Permission).WithMany(n => n.PermissionRoles).HasForeignKey(n => n.PermissionID);
			permissionRole.HasOne(n => n.Role).WithMany(n => n.Permissions).HasForeignKey(n => n.RoleID);

			var actionLog = modelBuilder.Entity<ActionLog>();
			actionLog.ToTable("ActionLogs");
			actionLog.Property(n => n.Title).IsRequired().HasColumnType("nvarchar(200) COLLATE Latin1_General_CI_AI");
			actionLog.Property(n => n.Description).HasColumnType("nvarchar(500) ");
			actionLog.Property(n => n.CreatedDate).HasDefaultValue(DateTime.Now);

			var banner = modelBuilder.Entity<Banner>();
			banner.ToTable("Banners");
			banner.Property(n => n.CreateDate).HasDefaultValue(DateTime.Now);
			banner.Property(n => n.Name).HasMaxLength(300).IsUnicode(true).HasColumnType("nvarchar(300) COLLATE Latin1_General_CI_AI");
			banner.Property(n => n.Title).HasMaxLength(300).IsUnicode(true).HasColumnType("nvarchar(300) COLLATE Latin1_General_CI_AI");
			banner.Property(n => n.Media).HasMaxLength(500).IsUnicode(true);
			banner.Property(n => n.Summary).HasMaxLength(500).IsUnicode(true);
			banner.Property(n => n.Description).HasMaxLength(2000).IsUnicode(true);
			banner.Property(n => n.Status).HasDefaultValue(0);

			var book = modelBuilder.Entity<Book>();
			book.ToTable("Books");
			book.Property(n => n.CreatedDate).HasDefaultValue(DateTime.Now);
			book.Property(n => n.BookName).HasColumnType("nvarchar(300) COLLATE Latin1_General_CI_AI");
			book.Property(n => n.Description).HasColumnType("nvarchar(max)");
			book.Property(n => n.Title).HasColumnType("nvarchar(200) COLLATE Latin1_General_CI_AI");
			book.Property(n => n.Author).HasColumnType("nvarchar(200) COLLATE Latin1_General_CI_AI");
			book.Property(n => n.Language).HasColumnType("nvarchar(100) COLLATE Latin1_General_CI_AI");
			book.Property(n => n.CoverType).HasColumnType("nvarchar(50) COLLATE Latin1_General_CI_AI");
			book.Property(n => n.ISBN).HasMaxLength(50);
			book.Property(n => n.Status).HasDefaultValue(0);
			book.Property(n => n.Translator).HasColumnType("nvarchar(200) COLLATE Latin1_General_CI_AI");
			book.Property(n => n.Url).HasMaxLength(200).IsUnicode(false);
			book.Property(n => n.PublishingHouse).HasColumnType("nvarchar(200) COLLATE Latin1_General_CI_AI");
			book.HasOne(n => n.IssuingUnit).WithMany(n => n.Books).HasForeignKey(n => n.IssuingUnitID);
			book.HasOne(n => n.Menu).WithMany(n => n.Books).HasForeignKey(n => n.MenuID);
			book.HasMany(n => n.BookGenres).WithOne(n => n.Book);
			book.HasMany(n => n.BookImages).WithOne(n => n.Book);
			book.HasMany(n => n.PurchaseDetails).WithOne(n => n.Book);
			book.HasMany(n => n.OrderDetails).WithOne(n => n.Book);
			book.HasMany(n => n.Warehouses).WithOne(n => n.Book);
			book.HasMany(n => n.ComboBooks).WithOne(n => n.Book);
			book.HasMany(n => n.BookRatings).WithOne(n => n.Book);
			book.HasMany(n => n.ShoppingCarts).WithOne(n => n.Book);
			book.HasMany(n => n.BookReviews).WithOne(n => n.Book);
			book.HasMany(n => n.Comments).WithOne(n => n.Book);


			var bookImage = modelBuilder.Entity<BookImage>();
			bookImage.ToTable("BookImages");
			bookImage.Property(n => n.IsDefault).HasDefaultValue(false);
			bookImage.Property(n => n.Image).HasMaxLength(200).IsUnicode(false);
			bookImage.HasOne(n => n.Book).WithMany(n => n.BookImages).HasForeignKey(n => n.BookID);

			var bookRating = modelBuilder.Entity<BookRating>();
			bookRating.ToTable("BookRatings");
			bookRating.HasKey(n => new { n.UserID, n.BookID });
			bookRating.Property(n => n.CreateDate).HasDefaultValue(DateTime.Now);
			bookRating.HasOne(n => n.Book).WithMany(n => n.BookRatings).HasForeignKey(n => n.BookID);
			bookRating.HasOne(n => n.User).WithMany(n => n.BookRatings).HasForeignKey(n => n.UserID);

			var bookReview = modelBuilder.Entity<BookReview>();
			bookReview.ToTable("BookReviews");
			bookReview.HasKey(n => n.BookID);
			bookReview.Property(n => n.Rate).HasColumnType("decimal(1,1)");
			bookReview.HasOne(n => n.Book).WithMany(n => n.BookReviews).HasForeignKey(n => n.BookID);

			var bookGenres = modelBuilder.Entity<BookGenres>();
			bookGenres.ToTable("BookGenres");
			bookGenres.HasKey(n => new { n.BookID, n.GenresID });
			bookGenres.HasOne(n => n.Book).WithMany(n => n.BookGenres).HasForeignKey(n => n.BookID);
			bookGenres.HasOne(n => n.Genres).WithMany(n => n.BookGenres).HasForeignKey(n => n.GenresID);

			var genres = modelBuilder.Entity<Genres>();
			genres.ToTable("Genres");
			genres.Property(n => n.CreatedDate).HasDefaultValue(DateTime.Now);
			genres.Property(n => n.Name).HasColumnType("nvarchar(200) COLLATE Latin1_General_CI_AI");
			genres.Property(n => n.Description).HasColumnType("nvarchar(200)");
			genres.HasMany(n => n.BookGenres).WithOne(n => n.Genres);

			var category = modelBuilder.Entity<Category>();
			category.ToTable("Categories");
			category.Property(n => n.CreatedDate).HasDefaultValue(DateTime.Now);
			category.Property(n => n.CategoryName).HasColumnType("nvarchar(200) COLLATE Latin1_General_CI_AI");
			category.Property(n => n.Description).HasColumnType("nvarchar(500)");

			var client = modelBuilder.Entity<Client>();
			client.ToTable("Clients");
			client.Property(n => n.Name).HasColumnType("nvarchar(200) COLLATE Latin1_General_CI_AI");
			client.Property(n => n.Description).HasColumnType("nvarchar(500)");
			client.Property(n => n.Address).HasColumnType("nvarchar(100) COLLATE Latin1_General_CI_AI");
			client.Property(n => n.PhoneNumber).HasMaxLength(30).IsUnicode(false);
			client.Property(n => n.Gender).IsRequired().HasDefaultValue(0);
			client.Property(n => n.Email).HasMaxLength(100).IsUnicode(false);
			client.Property(n => n.CreateDate).HasDefaultValue(DateTime.Now);
			client.HasMany(n => n.Order).WithOne(n => n.Client);

			var combo = modelBuilder.Entity<Combo>();
			combo.ToTable("Combos");
			combo.Property(n => n.Name).IsRequired().HasColumnType("nvarchar(200) COLLATE Latin1_General_CI_AI");
			combo.Property(n => n.Description).HasColumnType("nvarchar(max)");
			combo.Property(n => n.CreateDate).HasDefaultValue(DateTime.Now);
			combo.Property(n => n.IsActive).HasDefaultValue(false);
			combo.Property(n => n.Image).HasMaxLength(200).IsUnicode(false);
			combo.HasMany(n => n.Books).WithOne(n => n.Combo);

			var comboBook = modelBuilder.Entity<ComboBook>();
			comboBook.ToTable("ComboBooks");
			comboBook.HasKey(n => new { n.ComboID, n.BookID });
			comboBook.HasOne(n => n.Book).WithMany(n => n.ComboBooks).HasForeignKey(n => n.BookID);
			comboBook.HasOne(n => n.Combo).WithMany(n => n.Books).HasForeignKey(n => n.ComboID);

			var comment = modelBuilder.Entity<Comment>();
			comment.ToTable("Comments");
			comment.Property(n => n.CreateDate).HasDefaultValue(DateTime.Now);
			comment.Property(n => n.Detail).HasColumnType("nvarchar(1000)");
			comment.HasOne(n => n.Book).WithMany(n => n.Comments).HasForeignKey(n => n.BookID);
			comment.HasOne(n => n.User).WithMany(n => n.Comments).HasForeignKey(n => n.UserID);

			var issuingUnit = modelBuilder.Entity<IssuingUnit>();
			issuingUnit.ToTable("IssuingUnits");
			issuingUnit.Property(n => n.CreatedDate).HasDefaultValue(DateTime.Now);
			issuingUnit.Property(n => n.Name).HasColumnType("nvarchar(200) COLLATE Latin1_General_CI_AI");
			issuingUnit.Property(n => n.StartDate).HasDefaultValue(DateTime.Now);
			issuingUnit.Property(n => n.PhoneNumber).HasMaxLength(30);
			issuingUnit.Property(n => n.Address).HasMaxLength(200).IsUnicode(true);
			issuingUnit.Property(n => n.Email).HasMaxLength(100).IsUnicode(false);
			issuingUnit.Property(n => n.Status).HasDefaultValue(0);
			issuingUnit.HasMany(n => n.Purchases).WithOne(n => n.IssuingUnit);
			issuingUnit.HasMany(n => n.Books).WithOne(n => n.IssuingUnit);

			var job = modelBuilder.Entity<Job>();
			job.ToTable("Jobs");
			job.Property(n => n.CreatedDate).HasDefaultValue(DateTime.Now);
			job.Property(n => n.JobName).HasColumnType("nvarchar(200) COLLATE Latin1_General_CI_AI");
			job.Property(n => n.Description).HasMaxLength(500).IsUnicode(true);
			job.Property(n => n.SalaryMin).HasDefaultValue(0).HasColumnType("decimal(18,2)");
			job.Property(n => n.SalaryMax).HasDefaultValue(0).HasColumnType("decimal(18,2)");
			job.HasMany(n => n.Staffs).WithOne(n => n.Job);

			var menu = modelBuilder.Entity<Menu>();
			menu.ToTable("Menus");
			menu.Property(n => n.Name).HasColumnType("nvarchar(200) COLLATE Latin1_General_CI_AI");
			menu.Property(n => n.Target).HasMaxLength(30).IsUnicode(false).HasDefaultValue("_blank");
			menu.Property(n => n.Url).HasMaxLength(200).IsUnicode(false);
			menu.Property(n => n.CreateBy).HasMaxLength(200).IsUnicode(true);
			menu.Property(n => n.ModifiedBy).HasMaxLength(200).IsUnicode(true);
			menu.Property(n => n.CreateDate).HasDefaultValue(DateTime.Now);
			menu.Property(n => n.Priority).HasDefaultValue(0);
			menu.Property(n => n.Status).HasDefaultValue(0);
			menu.HasMany(n => n.Books).WithOne(n => n.Menu);

			var order = modelBuilder.Entity<Order>();
			order.ToTable("Orders");
			order.Property(n => n.CreatedDate).HasDefaultValue(DateTime.Now);
			order.Property(n => n.TotalAmount).HasDefaultValue(0).HasColumnType("decimal(18,2)");
			order.HasMany(n => n.Shippings).WithOne(n => n.Order);
			order.HasMany(n => n.Details).WithOne(n => n.Order);
			order.HasOne(n => n.Client).WithMany(n => n.Order).HasForeignKey(n => n.ClientID);

			var orderDetail = modelBuilder.Entity<OrderDetail>();
			orderDetail.ToTable("OrderDetails");
			orderDetail.HasKey(n => new { n.OrderID, n.BookID });
			orderDetail.Property(n => n.CreatedDate).HasDefaultValue(DateTime.Now);
			orderDetail.Property(n => n.NetPrice).HasDefaultValue(0).HasColumnType("decimal(18,2)");
			orderDetail.Property(n => n.UnitPrice).HasDefaultValue(0).HasColumnType("decimal(18,2)");
			orderDetail.Property(n => n.Quantity).HasDefaultValue(0);
			orderDetail.HasOne(n => n.Order).WithMany(n => n.Details).HasForeignKey(n => n.OrderID);
			orderDetail.HasOne(n => n.Book).WithMany(n => n.OrderDetails).HasForeignKey(n => n.BookID);

			var purchase = modelBuilder.Entity<Purchase>();
			purchase.ToTable("Purchase");
			purchase.Property(n => n.CreatedDate).HasDefaultValue(DateTime.Now);
			purchase.Property(n => n.TotalAmount).HasDefaultValue(0).HasColumnType("decimal(18,2)");
			purchase.HasMany(n => n.PurchaseDetails).WithOne(n => n.Purchase);
			purchase.HasOne(n => n.IssuingUnit).WithMany(n => n.Purchases).HasForeignKey(n => n.IssuingUnitID);

			var purchaseDetail = modelBuilder.Entity<PurchaseDetail>();
			purchaseDetail.ToTable("PurchaseDetails");
			purchaseDetail.HasKey(n => new { n.PurchaseID, n.BookID });
			purchaseDetail.Property(n => n.CreatedDate).HasDefaultValue(DateTime.Now);
			purchaseDetail.Property(n => n.NetPrice).HasDefaultValue(0).HasColumnType("decimal(18,2)");
			purchaseDetail.Property(n => n.UnitPrice).HasDefaultValue(0).HasColumnType("decimal(18,2)");
			purchaseDetail.Property(n => n.Quantity).HasDefaultValue(0);
			purchaseDetail.HasOne(n => n.Purchase).WithMany(n => n.PurchaseDetails).HasForeignKey(n => n.PurchaseID);
			purchaseDetail.HasOne(n => n.Book).WithMany(n => n.PurchaseDetails).HasForeignKey(n => n.BookID).OnDelete(DeleteBehavior.Restrict);

			var qa=modelBuilder.Entity<QuestionAndAnswer>();
			qa.ToTable("QuestionAndAnswer");
			qa.Property(n => n.Answer).HasColumnType("nvarchar(200) COLLATE Latin1_General_CI_AI");
			qa.Property(n =>n.Question ).HasColumnType("nvarchar(2000) COLLATE Latin1_General_CI_AI");
			qa.Property(n => n.CreateDate).HasDefaultValue(DateTime.Now);
			qa.Property(n => n.Status).HasDefaultValue(0);

			var shipping=modelBuilder.Entity<Shipping>();
			shipping.ToTable("Shipping");
			shipping.HasKey(n => n.OrderID);
			shipping.Property(n => n.CreatedDate).HasDefaultValue(DateTime.Now);
			shipping.Property(n => n.ShoppingCost).HasDefaultValue(0).HasColumnType("decimal(18,2)");
			shipping.Property(n => n.Carrier).HasMaxLength(500).IsUnicode(true);
			shipping.HasOne(n => n.Order).WithMany(n => n.Shippings).HasForeignKey(n => n.OrderID);

			var shoppingCart = modelBuilder.Entity<ShoppingCart>();
			shoppingCart.ToTable("ShoppingCarts");
			shoppingCart.HasKey(n => new { n.UserID, n.BookID });
			shoppingCart.Property(n => n.Code).HasMaxLength(100).IsUnicode(false);
            shoppingCart.Property(n => n.Status).HasDefaultValue(0);
			shoppingCart.HasOne(n => n.User).WithMany(n => n.ShoppingCarts).HasForeignKey(n => n.UserID);
			shoppingCart.HasOne(n => n.Book).WithMany(n => n.ShoppingCarts).HasForeignKey(n => n.BookID);


			var staff = modelBuilder.Entity<Staff>();
			staff.ToTable("Staffs");
			staff.Property(n => n.CreatedDate).HasDefaultValue(DateTime.Now);
			staff.Property(n => n.StaffName).HasColumnType("nvarchar(200) COLLATE Latin1_General_CI_AI");
			staff.Property(n => n.Biography).HasColumnType("nvarchar(max)");
			staff.Property(n => n.DateOfBirth).IsRequired();
			staff.Property(n =>n.Salary ).IsRequired().HasDefaultValue(0).HasColumnType("decimal(18,2)");
			staff.Property(n => n.Address).HasColumnType("nvarchar(100) COLLATE Latin1_General_CI_AI");
			staff.Property(n => n.PhoneNumber).HasMaxLength(30).IsUnicode(false);
			staff.Property(n => n.Gender).IsRequired().HasDefaultValue(0);
			staff.Property(n => n.Email).HasMaxLength(100).IsUnicode(false);
			staff.Property(n=>n.StartDate).HasDefaultValue(DateTime.Now);
			staff.Property(n => n.Avatar).HasMaxLength(200).IsUnicode(false);
			staff.Property(n => n.Status).HasDefaultValue(0);

			var config = modelBuilder.Entity<SystemConfig>();
			config.ToTable("SystemConfigs");
			config.Property(n => n.CreatedDate).HasDefaultValue(DateTime.Now);
			config.Property(n => n.Value).HasMaxLength(500).IsUnicode(true);
			config.Property(n => n.Data).HasMaxLength(500).IsUnicode(true);
			config.Property(n => n.ExData).HasMaxLength(1000).IsUnicode(true);
			config.Property(n => n.Image).HasMaxLength(500).IsUnicode(true);
			config.Property(n => n.Status).HasDefaultValue(0);

			var wareHouse = modelBuilder.Entity<Warehouse>();
			wareHouse.ToTable("WareHouses");
			wareHouse.HasKey(n => n.BookID);
			wareHouse.Property(n => n.CreatedDate).HasDefaultValue(DateTime.Now);
			wareHouse.Property(n => n.InventoryQuantity).IsRequired();
			wareHouse.HasOne(n => n.Book).WithMany(n => n.Warehouses).HasForeignKey(n => n.BookID);


		}
	}
	public class AppDbContextFactory : IDesignTimeDbContextFactory<ApplicationDBContext>
	{
		public ApplicationDBContext CreateDbContext(string[] args)
		{
			var builder = new DbContextOptionsBuilder<ApplicationDBContext>();
			var connectionString = "Data Source=LAPTOP-FT5F2K76\\SQLEXPRESS;Initial Catalog=QuanLyBanSach;User Id=sa;Password=123456;TrustServerCertificate=True";
			builder.UseSqlServer(connectionString);

			return new ApplicationDBContext(builder.Options);
		}
	}

}
