using System;
using System.Collections.Generic;

namespace MetroSystem.Data.Models;

public partial class Bookmark
{
    public int BookmarkId { get; set; }

    public int UserId { get; set; }

    public int? LineId { get; set; }

    public int? StationId { get; set; }

    public bool? Status { get; set; }

    public virtual MetroLine? Line { get; set; }

    public virtual MetroStation? Station { get; set; }

    public virtual User User { get; set; } = null!;
}
