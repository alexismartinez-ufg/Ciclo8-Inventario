using System;
using System.Collections.Generic;

namespace InventarioDAL;

public partial class District
{
    public int IdDistrict { get; set; }

    public string DistrictName { get; set; } = null!;

    public int IdMunicipality { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual Municipality IdMunicipalityNavigation { get; set; } = null!;
}
