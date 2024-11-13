using System;
using System.Collections.Generic;

namespace InventarioDAL;

public partial class Supplier
{
    public int IdSupplier { get; set; }

    public string SupplierName { get; set; } = null!;

    public string SupplierAddress { get; set; } = null!;

    public string SupplierPhone { get; set; } = null!;

    public string SupplierEmail { get; set; } = null!;

    public string? SupplierCountry { get; set; }

    public bool SupplierStatus { get; set; }

    public virtual ICollection<Brand> Brands { get; set; } = new List<Brand>();

    public virtual ICollection<InventoryMovement> InventoryMovements { get; set; } = new List<InventoryMovement>();

    public virtual ICollection<SupplierContact> SupplierContacts { get; set; } = new List<SupplierContact>();
}
