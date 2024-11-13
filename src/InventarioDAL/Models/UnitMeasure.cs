using System;
using System.Collections.Generic;

namespace InventarioDAL;

public partial class UnitMeasure
{
    public int IdUnitMeasure { get; set; }

    public string UnitMeasureName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
