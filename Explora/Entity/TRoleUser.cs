using System;
using System.Collections.Generic;

namespace Explora.Entity;

public partial class TRoleUser
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public int UserId { get; set; }

    public virtual TRole Role { get; set; } = null!;

    public virtual TUser User { get; set; } = null!;
}
