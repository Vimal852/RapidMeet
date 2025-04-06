namespace RapidMeet.Domain.Entities;

public class Permission
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public string PermissionName { get; set; } = string.Empty;
}
