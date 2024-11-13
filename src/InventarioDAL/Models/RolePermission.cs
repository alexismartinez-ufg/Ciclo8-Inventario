using System.Text.Json.Serialization;

namespace InventarioDAL;

public partial class RolePermission
{
    public int IdRole { get; set; }

    public int IdPermission { get; set; }

    public bool RolePermissionStatus { get; set; }

    [JsonIgnore]
    public virtual Permission IdPermissionNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual Role IdRoleNavigation { get; set; } = null!;
}
