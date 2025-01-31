namespace APIBook.Dtos;

public class AttachmentDto
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? Extention { get; set; }
    public string? Url { get; set; }
    public float? Size { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid? CreatedBy { get; set; }
    public Guid? AttachmentFolderId { get; set;}
}