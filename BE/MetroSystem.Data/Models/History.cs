using System;
using System.Collections.Generic;

namespace MetroSystem.Data.Models;

public partial class History
{
    public int HistoryId { get; set; }

    public int UserId { get; set; }

    public DateTime? Timestamp { get; set; }

    public string? Message { get; set; }

    public int? RecommendId { get; set; }

    public virtual User User { get; set; } = null!;
}
