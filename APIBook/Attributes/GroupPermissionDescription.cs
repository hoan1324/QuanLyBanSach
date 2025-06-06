namespace APIBook.Attributes
{
    public class GroupPermissionDescriptionAttribute : Attribute
    {
        public string Description { get; set; }
        public GroupPermissionDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
