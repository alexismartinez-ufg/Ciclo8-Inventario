using System;
using System.Collections.Generic;

namespace InventarioDAL;

public partial class RolePermission
{
    public int IdRole { get; set; }

    public int IdPermission { get; set; }

    public bool RolePermissionStatus { get; set; }

    public virtual Permission IdPermissionNavigation { get; set; } = null!;

    public virtual Role IdRoleNavigation { get; set; } = null!;
}
