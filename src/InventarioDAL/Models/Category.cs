using System;
using System.Collections.Generic;

namespace InventarioDAL;

public partial class Category
{
    public int IdCategory { get; set; }

    public string CategoryName { get; set; } = null!;

    public bool CategoryStatus { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
