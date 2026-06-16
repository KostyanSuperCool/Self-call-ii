using System;
using System.Collections.Generic;

namespace Self_call_ii;

public partial class ScCart
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime? AddedAt { get; set; }

    public virtual ScProduct Product { get; set; } = null!;

    public virtual ScUser User { get; set; } = null!;
}
