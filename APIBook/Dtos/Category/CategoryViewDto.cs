namespace APIBook.Dtos
{
    public class CategoryViewDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedByUserName { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedByUserName { get; set; }
       
    }
}
