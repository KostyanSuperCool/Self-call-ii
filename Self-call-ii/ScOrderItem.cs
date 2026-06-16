using System;
using System.Collections.Generic;

namespace Self_call_ii;

public partial class ScOrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal PriceAtOrder { get; set; }

    public int Quantity { get; set; }

    public virtual ScOrder Order { get; set; } = null!;
}
