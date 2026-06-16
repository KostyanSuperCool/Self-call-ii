using System;
using System.Collections.Generic;

namespace Self_call_ii;

public partial class ScCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? SortOrder { get; set; }

    public virtual ICollection<ScProduct> ScProducts { get; set; } = new List<ScProduct>();
}
