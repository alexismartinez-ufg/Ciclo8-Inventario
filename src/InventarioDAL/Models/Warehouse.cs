using System.Text.Json.Serialization;

namespace InventarioDAL;

public partial class Warehouse
{
    public int IdWarehouse { get; set; }

    public string WarehouseName { get; set; } = null!;

    public string WarehouseLocation { get; set; } = null!;

    public bool WarehouseClimateControlled { get; set; }

    public bool WarehouseStatus { get; set; }

    [JsonIgnore]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
