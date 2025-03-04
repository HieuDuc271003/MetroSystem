﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MetroSystem.Data.Models;

public partial class MetroLine
{
    public string LineId { get; set; }

    public string LineName { get; set; }

    public double Distance { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<MetroStation> MetroStations { get; set; } = new List<MetroStation>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}