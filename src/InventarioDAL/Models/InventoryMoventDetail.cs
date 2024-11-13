using System.Text.Json.Serialization;

namespace InventarioDAL;

public partial class InventoryMoventDetail
{
    public int IdMoventDetail { get; set; }

    public double? Quantity { get; set; }

    public string? UnitCost { get; set; }

    public string? TotalCost { get; set; }

    public int IdMovement { get; set; }

    public int IdProduct { get; set; }

    [JsonIgnore]
    public virtual InventoryMovement IdMovementNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual Product IdProductNavigation { get; set; } = null!;
}
