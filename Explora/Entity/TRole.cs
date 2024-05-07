using System;
using System.Collections.Generic;

namespace Explora.Entity;

public partial class TRole
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public string StatusRole { get; set; } = null!;

    public virtual ICollection<TRoleUser> TRoleUsers { get; set; } = new List<TRoleUser>();
}
