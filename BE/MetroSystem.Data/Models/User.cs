using System;
using System.Collections.Generic;

namespace MetroSystem.Data.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public bool? Status { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    public virtual Role Role { get; set; } = null!;
}
