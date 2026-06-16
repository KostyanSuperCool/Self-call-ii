using System;
using System.Collections.Generic;

namespace Self_call_ii;

public partial class ScPickupPoint
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string? Building { get; set; }

    public string? WorkTime { get; set; }

    public string? Phone { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<ScOrder> ScOrders { get; set; } = new List<ScOrder>();
}
