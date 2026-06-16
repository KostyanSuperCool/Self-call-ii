using System;
using System.Collections.Generic;

namespace Self_call_ii;

public partial class ScProduct
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string? PhotoUrl { get; set; }

    public bool? IsActive { get; set; }

    public int? StockQuantity { get; set; }

    public bool? IsPromotion { get; set; }

    public bool? IsTopProduct { get; set; }

    public virtual ScCategory Category { get; set; } = null!;

    public virtual ICollection<ScCart> ScCarts { get; set; } = new List<ScCart>();
}
