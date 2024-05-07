using System;
using System.Collections.Generic;

namespace Explora.Entity;

public partial class TAirline
{
    public int IdAirline { get; set; }

    public string AirlineName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string AddressAirline { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int IsDelete { get; set; }

    public virtual ICollection<TPlane> TPlanes { get; set; } = new List<TPlane>();
}
