using System;
using System.Collections.Generic;

namespace Explora.Entity;

public partial class TBillRoom
{
    public int BillId { get; set; }

    public string GuessName { get; set; } = null!;

    public string GuessEmail { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int TotalPrice { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public DateTime BuyTime { get; set; }

    public int UserId { get; set; }

    public int IdRoom { get; set; }

    public virtual TRoom IdRoomNavigation { get; set; } = null!;

    public virtual TUser User { get; set; } = null!;
}
