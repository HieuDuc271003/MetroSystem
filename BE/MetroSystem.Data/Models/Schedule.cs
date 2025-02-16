using System;
using System.Collections.Generic;

namespace MetroSystem.Data.Models;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public int LineId { get; set; }

    public int StationId { get; set; }

    public TimeOnly ArrivalTime { get; set; }

    public TimeOnly DepartureTime { get; set; }

    public virtual MetroLine Line { get; set; } = null!;

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    public virtual MetroStation Station { get; set; } = null!;
}
