using System.Text.Json.Serialization;

namespace InventarioDAL;

public partial class Role
{
    public int IdRole { get; set; }

    public string RoleName { get; set; } = null!;

    public bool RoleStatus { get; set; }

    [JsonIgnore]
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    [JsonIgnore]
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
