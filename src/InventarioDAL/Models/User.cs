using System.Text.Json.Serialization;

namespace InventarioDAL;

public partial class User
{
    public int IdUser { get; set; }

    public string NameUser { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string UserPosition { get; set; } = null!;

    public bool UserStatus { get; set; }

    public int IdUserPosition { get; set; }
    
    [JsonIgnore]
    public virtual UserPosition IdUserPositionNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<InventoryMovement> InventoryMovements { get; set; } = new List<InventoryMovement>();
    
    [JsonIgnore]
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
