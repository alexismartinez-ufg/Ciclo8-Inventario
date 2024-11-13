using System;
using System.Collections.Generic;

namespace InventarioDAL;

public partial class InventoryMoventDetail
{
    public int IdMoventDetail { get; set; }

    public double? Quantity { get; set; }

    public string? UnitCost { get; set; }

    public string? TotalCost { get; set; }

    public int IdMovement { get; set; }

    public int IdProduct { get; set; }

    public virtual InventoryMovement IdMovementNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
