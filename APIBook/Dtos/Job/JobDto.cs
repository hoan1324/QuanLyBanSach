﻿namespace APIBook.Dtos
{
	public class JobDto
	{
		public Guid Id { get; set; }
		public required string JobName { get; set; }
		public string? Description { get; set; }
		public decimal SalaryMax { get; set; }
		public decimal SalaryMin { get; set; }
	}
}