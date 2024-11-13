using System;
using System.Collections.Generic;

namespace InventarioDAL;

public partial class Role
{
    public int IdRole { get; set; }

    public string RoleName { get; set; } = null!;

    public bool RoleStatus { get; set; }

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
