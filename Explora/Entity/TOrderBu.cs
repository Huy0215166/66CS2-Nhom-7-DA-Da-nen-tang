using System;
using System.Collections.Generic;

namespace Explora.Entity;

public partial class TOrderBu
{
    public int OrderId { get; set; }

    public int Amount { get; set; }

    public int TotalPrice { get; set; }

    public DateTime BuyTime { get; set; }

    public int UserId { get; set; }

    public int IdBus { get; set; }

    public virtual TBu IdBusNavigation { get; set; } = null!;

    public virtual ICollection<TBusTicket> TBusTickets { get; set; } = new List<TBusTicket>();

    public virtual TUser User { get; set; } = null!;
}
