﻿using MetroSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Data.Interface
{
    public interface IBusStationRepository
    {
        Task<bool> AddBusStationAsync(BusStation busStation);
        Task<BusStation> GetBusStationByIdAsync(string stationId);
        Task<bool> UpdateBusStationAsync(BusStation busStation);
        Task<List<BusStation>> GetBusStationsByNameAsync(string stationName);
    }
}
