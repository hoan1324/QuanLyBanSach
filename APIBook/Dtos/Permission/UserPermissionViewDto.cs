namespace Api.Dtos;

public class UserPermissionViewDto
{
    public Guid? UserId { get; set; }
    public Guid? PermissionId { get; set; }
    public string? PermissionCode { get; set; }
}