using System;
using System.Collections.Generic;

namespace Explora.Entity;

public partial class TOrderPlane
{
    public int OrderId { get; set; }

    public int Amount { get; set; }

    public int TotalPrice { get; set; }

    public DateTime BuyTime { get; set; }

    public int UserId { get; set; }

    public int IdPlane { get; set; }

    public virtual TPlane IdPlaneNavigation { get; set; } = null!;

    public virtual ICollection<TPlaneTicket> TPlaneTickets { get; set; } = new List<TPlaneTicket>();

    public virtual TUser User { get; set; } = null!;
}
