using System.Text.Json.Serialization;

namespace InventarioDAL;

public partial class UserPosition
{
    public int IdUserPosition { get; set; }

    public string UserPositionName { get; set; } = null!;

    public bool UserPositionStatus { get; set; }

    [JsonIgnore]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
