using System;
using System.Collections.Generic;

namespace Explora.Entity;

public partial class TPlaneTicket
{
    public int TicketId { get; set; }

    public int OrderId { get; set; }

    public string GuessName { get; set; } = null!;

    public string GuessEmail { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Nationality { get; set; } = null!;

    public string PasspostNumber { get; set; } = null!;

    public DateTime ExpiredTime { get; set; }

    public int IdPlane { get; set; }

    public virtual TPlane IdPlaneNavigation { get; set; } = null!;

    public virtual TOrderPlane Order { get; set; } = null!;
}
