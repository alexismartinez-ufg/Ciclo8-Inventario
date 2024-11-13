using System.Text.Json.Serialization;

namespace InventarioDAL;

public partial class Category
{
    public int IdCategory { get; set; }

    public string CategoryName { get; set; } = null!;

    public bool CategoryStatus { get; set; }
    
    [JsonIgnore]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
