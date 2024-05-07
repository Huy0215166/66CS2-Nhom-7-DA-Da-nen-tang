using System;
using System.Collections.Generic;

namespace Explora.Entity;

public partial class THotel
{
    public int IdHotel { get; set; }

    public string HotelName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string AddressHotel { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int IsDelete { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<TRoom> TRooms { get; set; } = new List<TRoom>();

    public virtual TUser User { get; set; } = null!;
}
