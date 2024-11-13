using System;
using System.Collections.Generic;

namespace InventarioDAL;

public partial class Client
{
    public int IdClient { get; set; }

    public string ClientName { get; set; } = null!;

    public string ClientPhone { get; set; } = null!;

    public string ClientComplementAddress { get; set; } = null!;

    public int IdDistrict { get; set; }

    public virtual District IdDistrictNavigation { get; set; } = null!;

    public virtual ICollection<InventoryMovement> InventoryMovements { get; set; } = new List<InventoryMovement>();
}
