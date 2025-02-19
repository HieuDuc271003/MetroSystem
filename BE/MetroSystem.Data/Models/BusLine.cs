using System;
using System.Collections.Generic;

namespace MetroSystem.Data.Models;

public partial class BusLine
{
    public int BusLineId { get; set; }

    public string BusLineName { get; set; } = null!;

    public string Route { get; set; } = null!;

    public bool? Status { get; set; }

    public virtual ICollection<BusSchedule> BusSchedules { get; set; } = new List<BusSchedule>();
}
