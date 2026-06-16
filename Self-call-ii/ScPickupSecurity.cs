using System;
using System.Collections.Generic;

namespace Self_call_ii;

public partial class ScPickupSecurity
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public string SecurityMethod { get; set; } = null!;

    public DateTime? PersonConfirmedAt { get; set; }

    public string? PersonConfirmedBy { get; set; }

    public Guid? QrSecret { get; set; }

    public string? QrCode { get; set; }

    public bool? QrUsed { get; set; }

    public DateTime? QrUsedAt { get; set; }

    public string? QrUsedBy { get; set; }

    public int? PickupAttempts { get; set; }

    public DateTime? LastAttemptAt { get; set; }

    public virtual ScOrder Order { get; set; } = null!;
}
