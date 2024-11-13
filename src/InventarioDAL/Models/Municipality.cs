using System.Text.Json.Serialization;

namespace InventarioDAL;

public partial class Municipality
{
    public int IdMunicipality { get; set; }

    public int IdDeparment { get; set; }

    public string MunicipalityName { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<District> Districts { get; set; } = new List<District>();
    [JsonIgnore]
    public virtual Deparment IdDeparmentNavigation { get; set; } = null!;
}
