using System;
using System.Collections.Generic;

namespace Explora.Entity;

public partial class TBusTicket
{
    public int TicketId { get; set; }

    public int OrderId { get; set; }

    public string GuessName { get; set; } = null!;

    public string GuessEmail { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int IdBus { get; set; }

    public virtual TBu IdBusNavigation { get; set; } = null!;

    public virtual TOrderBu Order { get; set; } = null!;
}
