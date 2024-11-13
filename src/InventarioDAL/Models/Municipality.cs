using System;
using System.Collections.Generic;

namespace InventarioDAL;

public partial class Municipality
{
    public int IdMunicipality { get; set; }

    public int IdDeparment { get; set; }

    public string MunicipalityName { get; set; } = null!;

    public virtual ICollection<District> Districts { get; set; } = new List<District>();

    public virtual Deparment IdDeparmentNavigation { get; set; } = null!;
}
