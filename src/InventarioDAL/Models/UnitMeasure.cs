using System.Text.Json.Serialization;

namespace InventarioDAL;

public partial class UnitMeasure
{
    public int IdUnitMeasure { get; set; }

    public string UnitMeasureName { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
