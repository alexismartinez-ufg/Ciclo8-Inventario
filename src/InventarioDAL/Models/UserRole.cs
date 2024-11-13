using System.Text.Json.Serialization;

namespace InventarioDAL;

public partial class UserRole
{
    public int IdUser { get; set; }

    public int IdRole { get; set; }

    public bool UserRoleStatus { get; set; }

    [JsonIgnore]
    public virtual Role IdRoleNavigation { get; set; } = null!;
    
    [JsonIgnore]
    public virtual User IdUserNavigation { get; set; } = null!;
}
