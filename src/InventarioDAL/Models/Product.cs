using System;
using System.Collections.Generic;

namespace InventarioDAL;

public partial class Product
{
    public int IdProduct { get; set; }

    public int IdWarehouse { get; set; }

    public int IdCategory { get; set; }

    public int IdBrand { get; set; }

    public int IdUnitMeasure { get; set; }

    public string ProductReference { get; set; } = null!;

    public string? ProductName { get; set; }

    public string ProductDescription { get; set; } = null!;

    public string ProductBatch { get; set; } = null!;

    public string ProductSerial { get; set; } = null!;

    public DateOnly ProductFabricationDate { get; set; }

    public DateOnly ProductExpirationDate { get; set; }

    public int ProductQuantity { get; set; }

    public bool ProductStatus { get; set; }

    public virtual Brand IdBrandNavigation { get; set; } = null!;

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual UnitMeasure IdUnitMeasureNavigation { get; set; } = null!;

    public virtual Warehouse IdWarehouseNavigation { get; set; } = null!;

    public virtual ICollection<InventoryMoventDetail> InventoryMoventDetails { get; set; } = new List<InventoryMoventDetail>();
}
