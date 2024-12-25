using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class BookGenres
	{
		public Guid BookID { get; set; }
		public Guid GenresID { get; set; }
		public Book? Book { get; set; }
		public Genres? Genres { get; set; }

	}
}
