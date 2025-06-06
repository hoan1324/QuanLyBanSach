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
		public required string Name { get; set; }
		public string? Description { get; set; }
		public string? Title { get; set; }
		public required string  Author { get; set; }
		public int? PageNumber { get; set; }
		public DateTime? PublicationDate { get; set; }
		public string? Language { get; set; }
		public string? CoverType { get; set; }//loaij bia
		public string? ISBN { get; set; }
		public string? Translator { get; set; }
		public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }

        //public string? AgeRestriction {  get; set; }
        public required string PublishingHouse { get; set; }
		public int Status {  get; set; }//0:đc bán,1:ngưng bán
		public string? Url {  get; set; }
		public Guid MenuID { get; set; }
		public Guid IssuingUnitID {  get; set; }
		public Menu? Menu { get; set; }
		public virtual IssuingUnit? IssuingUnit { get; set; }
		public ICollection<BookGenres>? BookGenres { get; set; }
		public ICollection<BookImage>? BookImages { get; set; }
		public ICollection<PurchaseDetail>? PurchaseDetails { get; set; }
		public ICollection<OrderDetail>? OrderDetails { get; set; }
		public	ICollection<Warehouse>? Warehouses { get; set; }
		public ICollection<ComboBook>? ComboBooks { get; set; }
		public ICollection<BookRating>? BookRatings { get; set; }
		public ICollection<ShoppingCart>? ShoppingCarts { get; set; }
		public ICollection<BookReview>? BookReviews { get; set; }
		public ICollection<Comment>? Comments { get; set; }


	}
}
