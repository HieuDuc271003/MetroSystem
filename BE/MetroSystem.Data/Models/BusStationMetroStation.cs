using System;
using System.Collections.Generic;

namespace MetroSystem.Data.Models;

public partial class BusStationMetroStation
{
    public int Id { get; set; }

    public int BusStationId { get; set; }

    public int MetroStationId { get; set; }

    public double Distance { get; set; }

    public virtual BusStation BusStation { get; set; } = null!;

    public virtual MetroStation MetroStation { get; set; } = null!;
}
