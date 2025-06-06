namespace Api.Dtos
{
    public class PermissionDto
    {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
        public int Method { get; set; } //1:Create, 2:Read, 3:Update, 4:Delete
        public Guid? GroupPermissionId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public int Status { get; set; }//0:hoatj ddoong,//1 ban
	}
}
