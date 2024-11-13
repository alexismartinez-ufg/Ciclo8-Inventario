using System;
using System.Collections.Generic;

namespace InventarioDAL;

public partial class UserRole
{
    public int IdUser { get; set; }

    public int IdRole { get; set; }

    public bool UserRoleStatus { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
