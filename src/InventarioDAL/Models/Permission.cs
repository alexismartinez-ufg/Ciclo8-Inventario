using System.Text.Json.Serialization;

namespace InventarioDAL;

public partial class Permission
{
    public int IdPermission { get; set; }

    public string? PermissionName { get; set; }

    public bool PermissionStatus { get; set; }

    [JsonIgnore]
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
