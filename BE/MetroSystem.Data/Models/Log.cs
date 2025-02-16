using System;
using System.Collections.Generic;

namespace MetroSystem.Data.Models;

public partial class Log
{
    public int LogId { get; set; }

    public int UserId { get; set; }

    public int ScheduleId { get; set; }

    public string? Location { get; set; }

    public DateTime? Date { get; set; }

    public virtual Schedule Schedule { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
