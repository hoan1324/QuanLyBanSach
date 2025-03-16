namespace Api.Dtos
{
    public class PermissionDto
    {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public int Status { get; set; }//0:hoatj ddoong,//1 ban
		public DateTime? CreatedDate { get; set; }
	}
}
