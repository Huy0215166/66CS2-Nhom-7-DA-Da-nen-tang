using System;
using System.Collections.Generic;

namespace Explora.Entity;

public partial class TRoom
{
    public int IdRoom { get; set; }

    public int IdHotel { get; set; }

    public int Slot { get; set; }

    public int EmptySlot { get; set; }

    public int Price { get; set; }

    public string TypeRoom { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public int IsDelete { get; set; }

    public virtual THotel IdHotelNavigation { get; set; } = null!;

    public virtual ICollection<TBillRoom> TBillRooms { get; set; } = new List<TBillRoom>();
}
