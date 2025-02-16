using System;
using System.Collections.Generic;

namespace MetroSystem.Data.Models;

public partial class BusStation
{
    public int BusStationId { get; set; }

    public string BusStationName { get; set; } = null!;

    public string? Location { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<BusSchedule> BusSchedules { get; set; } = new List<BusSchedule>();

    public virtual ICollection<BusStationMetroStation> BusStationMetroStations { get; set; } = new List<BusStationMetroStation>();
}
