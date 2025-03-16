namespace APIBook.Attributes
{
	[AttributeUsage(AttributeTargets.Method)]
	public class PermissionDescriptionAttribute : Attribute
	{
		public string Description { get; set; }
		public PermissionDescriptionAttribute(string description)
		{
			Description = description;
		}
	}
}
