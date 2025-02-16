using System;
using System.Collections.Generic;

namespace MetroSystem.Data.Models;

public partial class BusSchedule
{
    public int ScheduleId { get; set; }

    public int BusLineId { get; set; }

    public int BusStationId { get; set; }

    public TimeOnly ArrivalTime { get; set; }

    public TimeOnly DepartureTime { get; set; }

    public string? DayType { get; set; }

    public virtual BusLine BusLine { get; set; } = null!;

    public virtual BusStation BusStation { get; set; } = null!;
}
