using System;
using System.Collections.Generic;
using System.Net;

namespace Self_call_ii;

public partial class ScPickupAudit
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public string? Action { get; set; }

    public string? Method { get; set; }

    public bool? Success { get; set; }

    public IPAddress? IpAddress { get; set; }

    public string? UserAgent { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ScOrder Order { get; set; } = null!;
}
