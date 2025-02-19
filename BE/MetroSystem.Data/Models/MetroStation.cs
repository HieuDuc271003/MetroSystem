using System;
using System.Collections.Generic;

namespace MetroSystem.Data.Models;

public partial class MetroStation
{
    public int StationId { get; set; }

    public string StationName { get; set; } = null!;

    public int LineId { get; set; }

    public string? Location { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();

    public virtual ICollection<BusStationMetroStation> BusStationMetroStations { get; set; } = new List<BusStationMetroStation>();

    public virtual MetroLine Line { get; set; } = null!;

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
