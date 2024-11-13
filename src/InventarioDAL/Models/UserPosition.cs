using System;
using System.Collections.Generic;

namespace InventarioDAL;

public partial class UserPosition
{
    public int IdUserPosition { get; set; }

    public string UserPositionName { get; set; } = null!;

    public bool UserPositionStatus { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
