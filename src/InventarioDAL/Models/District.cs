using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace InventarioDAL;

public partial class District
{
    public int IdDistrict { get; set; }

    public string DistrictName { get; set; } = null!;

    public int IdMunicipality { get; set; }

    [JsonIgnore]
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    [JsonIgnore]
    public virtual Municipality IdMunicipalityNavigation { get; set; } = null!;
}
