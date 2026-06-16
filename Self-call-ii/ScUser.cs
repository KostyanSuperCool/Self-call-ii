using System;
using System.Collections.Generic;

namespace Self_call_ii;

public partial class ScUser
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? PhotoUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ScCart> ScCarts { get; set; } = new List<ScCart>();

    public virtual ICollection<ScOrder> ScOrders { get; set; } = new List<ScOrder>();

    public virtual ICollection<ScProfile> ScProfiles { get; set; } = new List<ScProfile>();

    public virtual ICollection<ScSession> ScSessions { get; set; } = new List<ScSession>();
}
