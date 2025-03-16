namespace APIBook.Dtos
{
	public class JobDto
	{
		public Guid Id { get; set; }
		public required string Name { get; set; }
		public string? Description { get; set; }
		public DateTime? CreatedDate { get; set; }
		public decimal SalaryMax { get; set; }
		public decimal SalaryMin { get; set; }
	}
}
