using System.Text.Json.Serialization;

namespace InventarioDAL;

public partial class Deparment
{
    public int IdDeparment { get; set; }

    public string DeparmentName { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Municipality> Municipalities { get; set; } = new List<Municipality>();
}
