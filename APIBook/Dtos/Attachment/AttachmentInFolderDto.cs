namespace APIBook.Dtos
{
    public class AttachmentInFolderDto
    {
        public Guid FolderId { get; set; }
        public string? TextSearch { get; set; }
        public List<string>? Ext { get; set; }
        public int PageIndex { get; set; } = 1;
    }
}
