using System.Text.Json.Serialization;

namespace InventarioDAL;

public partial class SupplierContact
{
    public int IdContactSupplier { get; set; }

    public int IdSupplier { get; set; }

    public string ContactSupplierName { get; set; } = null!;

    public string ContactSupplierEmail { get; set; } = null!;

    public string ContactSupplierPhone { get; set; } = null!;

    public bool ContactSupplierStatus { get; set; }

    [JsonIgnore]
    public virtual Supplier IdSupplierNavigation { get; set; } = null!;
}
