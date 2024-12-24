using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class ComboBook
	{
		public Guid BookID { get; set; }
		public Guid ComboID {  get; set; }
		public Combo? Combo {  get; set; }
		public virtual Book? Book { get; set; }
	}
}
