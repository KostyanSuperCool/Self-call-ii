using System;
using System.Collections.Generic;

namespace Self_call_ii;

public partial class ScProfile
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? PassportData { get; set; }

    public bool? IsVerified { get; set; }

    public DateTime? VerifiedAt { get; set; }

    public virtual ScUser User { get; set; } = null!;
}
