using System.Text.Json.Serialization;

namespace InventarioDAL;

public partial class Brand
{
    public int IdBrand { get; set; }

    public int IdSupplier { get; set; }

    public string BrandName { get; set; } = null!;

    public bool BrandStatus { get; set; }

    public string BrandCountry { get; set; } = null!;

    [JsonIgnore]
    public virtual Supplier IdSupplierNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
