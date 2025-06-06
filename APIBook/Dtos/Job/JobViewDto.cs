namespace APIBook.Dtos
{
    public class JobViewDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedByUserName { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedByUserName { get; set; }
        public decimal SalaryMax { get; set; }
        public decimal SalaryMin { get; set; }
    }
}
