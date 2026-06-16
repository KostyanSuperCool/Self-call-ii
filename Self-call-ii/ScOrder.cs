using System;
using System.Collections.Generic;

namespace Self_call_ii;

public partial class ScOrder
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string OrderNumber { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public int PickupPointId { get; set; }

    public string? OrderStatus { get; set; }

    public string? PaymentStatus { get; set; }

    public bool? IsPaid { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? PaidAt { get; set; }

    public DateTime? ReadyAt { get; set; }

    public DateTime? PickedUpAt { get; set; }

    public string? Comment { get; set; }

    public virtual ScPickupPoint PickupPoint { get; set; } = null!;

    public virtual ICollection<ScOrderItem> ScOrderItems { get; set; } = new List<ScOrderItem>();

    public virtual ICollection<ScPickupAudit> ScPickupAudits { get; set; } = new List<ScPickupAudit>();

    public virtual ScPickupSecurity? ScPickupSecurity { get; set; }

    public virtual ScUser User { get; set; } = null!;
}
