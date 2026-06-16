using System;
using System.Collections.Generic;

namespace Self_call_ii;

public partial class ScSession
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Token { get; set; } = null!;

    public DateTime ExpiresAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ScUser User { get; set; } = null!;
}
