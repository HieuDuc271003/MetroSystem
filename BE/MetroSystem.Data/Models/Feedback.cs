using System;
using System.Collections.Generic;

namespace MetroSystem.Data.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int UserId { get; set; }

    public int? LineId { get; set; }

    public string? Comment { get; set; }

    public int? Rating { get; set; }

    public virtual MetroLine? Line { get; set; }

    public virtual User User { get; set; } = null!;
}
