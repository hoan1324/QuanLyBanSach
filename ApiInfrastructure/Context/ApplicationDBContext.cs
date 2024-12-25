using ApiDomain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiInfrastructure.Context
{
	public class ApplicationDBContext: DbContext
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
		public DbSet<BookType> BookTypes { get; set; }
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
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var user = modelBuilder.Entity<User>();
			user.ToTable("User");
			user.Property(n=>n.UserName).IsRequired().HasMaxLength(200).HasColumnType("nvarchar(200) COLLATE Latin1_General_CI_AI");
			user.Property(n => n.Password).IsRequired().HasMaxLength(200).IsUnicode(true);
			user.Property(n => n.PhoneNumber).IsRequired().HasMaxLength(15).IsUnicode(false);
			user.Property(n => n.Email).IsRequired().HasMaxLength(200).IsUnicode(false);


		}
	}
}
