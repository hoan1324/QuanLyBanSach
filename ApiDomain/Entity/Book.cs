using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class Book : Entity<Guid>
	{
		public required string BookName { get; set; }
		public string? Desccription { get; set; }
		public string? Title { get; set; }
		public required string Author { get; set; }
		public int? PageNumbe { get; set; }
		public DateTime? PublicationDate { get; set; }
		public string? Language { get; set; }
		public string? CoverType { get; set; }
		public string? ISBN { get; set; }
		public string? Translator { get; set; }
		public string? PublishingHouse { get; set; }
		public string? Url {  get; set; }
		public Guid IssuingUnitID {  get; set; }
		public Guid BookTypeID { get; set; }
		public virtual BookType? BookType { get; set; }
		public virtual IssuingUnit? IssuingUnit { get; set; }
		public ICollection<BookImage>? BookImages { get; set; }
		public ICollection<PurchaseDetail>? PurchaseDetails { get; set; }
		public ICollection<OrderDetail>? OrderDetails { get; set; }
		public	ICollection<Warehouse>? Warehouses { get; set; }
		public ICollection<ComboBook>? ComboBooks { get; set; }
		public ICollection<BookRating>? BookRatings { get; set; }
		public ICollection<ShoppingCart>? ShoppingCarts { get; set; }
		public ICollection<BookReview>? BookReviews { get; set; }



	}
}
