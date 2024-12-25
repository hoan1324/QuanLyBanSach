using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
	public class Staff : Entity<Guid>
	{
		public required string StaffName { get; set; }
		public string? Biography { get; set; }
		public  DateTime DateOfBirth { get; set; }
		public  decimal Salary {  get; set; }
		public required string Address {  get; set; }
		public required string PhoneNumber { get; set; }
		public required string Email { get; set; }
		public  DateTime StartDate {  get; set; }
		public DateTime? EndDate { get; set; }
		public string? Avatar {  get; set; }
		public required string Gender {  get; set; }
		public int Status {  get; set; }
	    public  Guid JobID { get; set; }
		public virtual Job? Job { get; set; }

	}
}
