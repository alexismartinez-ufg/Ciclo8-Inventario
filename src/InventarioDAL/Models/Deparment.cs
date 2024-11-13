using System;
using System.Collections.Generic;

namespace InventarioDAL;

public partial class Deparment
{
    public int IdDeparment { get; set; }

    public string DeparmentName { get; set; } = null!;

    public virtual ICollection<Municipality> Municipalities { get; set; } = new List<Municipality>();
}
