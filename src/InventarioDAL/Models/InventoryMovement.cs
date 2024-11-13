using System.Text.Json.Serialization;

namespace InventarioDAL;

public partial class InventoryMovement
{
    public int IdMovement { get; set; }

    public bool? MovementType { get; set; }

    public DateOnly? MovementDate { get; set; }

    public int IdUser { get; set; }

    public int? IdSupplier { get; set; }

    public int? IdClient { get; set; }

    public virtual Client? IdClientNavigation { get; set; }

    public virtual Supplier? IdSupplierNavigation { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<InventoryMoventDetail> InventoryMoventDetails { get; set; } = new List<InventoryMoventDetail>();
}
