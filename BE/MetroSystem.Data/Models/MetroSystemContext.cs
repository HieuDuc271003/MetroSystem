﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MetroSystem.Data.Models;

public partial class MetroSystemContext : DbContext
{
    public MetroSystemContext(DbContextOptions<MetroSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bookmark> Bookmarks { get; set; }

    public virtual DbSet<BusLine> BusLines { get; set; }

    public virtual DbSet<BusSchedule> BusSchedules { get; set; }

    public virtual DbSet<BusStation> BusStations { get; set; }

    public virtual DbSet<BusStationMetroStation> BusStationMetroStations { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<MetroLine> MetroLines { get; set; }

    public virtual DbSet<MetroStation> MetroStations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer(getConnectString());


    //private string getConnectString()
    //{
    //    IConfiguration config = new ConfigurationBuilder()
    //        .SetBasePath(Directory.GetCurrentDirectory()) // Sửa lỗi chỗ này
    //        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    //        .Build();

    //    var strConn = config.GetConnectionString("DefaultConnection");
    //    return strConn;
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bookmark>(entity =>
        {
            entity.HasKey(e => e.BookmarkId).HasName("PK__Bookmark__541A3A91B8F6C494");

            entity.ToTable("Bookmark");

            entity.Property(e => e.BookmarkId)
                .HasMaxLength(50)
                .HasColumnName("BookmarkID");
            entity.Property(e => e.LineId)
                .HasMaxLength(50)
                .HasColumnName("LineID");
            entity.Property(e => e.StationId)
                .HasMaxLength(50)
                .HasColumnName("StationID");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("UserID");

            entity.HasOne(d => d.Line).WithMany(p => p.Bookmarks)
                .HasForeignKey(d => d.LineId)
                .HasConstraintName("FK_Bookmark_Line");

            entity.HasOne(d => d.Station).WithMany(p => p.Bookmarks)
                .HasForeignKey(d => d.StationId)
                .HasConstraintName("FK_Bookmark_Station");

            entity.HasOne(d => d.User).WithMany(p => p.Bookmarks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookmark_User");
        });

        modelBuilder.Entity<BusLine>(entity =>
        {
            entity.HasKey(e => e.BusLineId).HasName("PK__BusLine__0FF2C3D394BFD73B");

            entity.ToTable("BusLine");

            entity.Property(e => e.BusLineId)
                .HasMaxLength(50)
                .HasColumnName("BusLineID");
            entity.Property(e => e.BusLineName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Route)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<BusSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__BusSched__9C8A5B6967728404");

            entity.ToTable("BusSchedule");

            entity.Property(e => e.ScheduleId)
                .HasMaxLength(50)
                .HasColumnName("ScheduleID");
            entity.Property(e => e.BusLineId)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("BusLineID");
            entity.Property(e => e.BusStationId)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("BusStationID");
            entity.Property(e => e.DayType).HasMaxLength(10);

            entity.HasOne(d => d.BusLine).WithMany(p => p.BusSchedules)
                .HasForeignKey(d => d.BusLineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BusSchedule_Line");

            entity.HasOne(d => d.BusStation).WithMany(p => p.BusSchedules)
                .HasForeignKey(d => d.BusStationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BusSchedule_Station");
        });

        modelBuilder.Entity<BusStation>(entity =>
        {
            entity.HasKey(e => e.BusStationId).HasName("PK__BusStati__BF771EE455D8A4CA");

            entity.ToTable("BusStation");

            entity.Property(e => e.BusStationId)
                .HasMaxLength(50)
                .HasColumnName("BusStationID");
            entity.Property(e => e.BusStationName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<BusStationMetroStation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BusStati__3214EC2793A08CEB");

            entity.ToTable("BusStation_MetroStation");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("ID");
            entity.Property(e => e.BusStationId)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("BusStationID");
            entity.Property(e => e.MetroStationId)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("MetroStationID");

            entity.HasOne(d => d.BusStation).WithMany(p => p.BusStationMetroStations)
                .HasForeignKey(d => d.BusStationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BusStation");

            entity.HasOne(d => d.MetroStation).WithMany(p => p.BusStationMetroStations)
                .HasForeignKey(d => d.MetroStationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MetroStation");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF66284A41F");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId)
                .HasMaxLength(50)
                .HasColumnName("FeedbackID");
            entity.Property(e => e.Comment).HasMaxLength(1000);
            entity.Property(e => e.LineId)
                .HasMaxLength(50)
                .HasColumnName("LineID");
            entity.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("UserID");

            entity.HasOne(d => d.Line).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.LineId)
                .HasConstraintName("FK_Feedback_Line");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feedback_User");
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.HasKey(e => e.HistoryId).HasName("PK__History__4D7B4ADD0F977F6E");

            entity.ToTable("History");

            entity.Property(e => e.HistoryId)
                .HasMaxLength(50)
                .HasColumnName("HistoryID");
            entity.Property(e => e.Message).HasMaxLength(1000);
            entity.Property(e => e.RecommendId)
                .HasMaxLength(50)
                .HasColumnName("RecommendID");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Histories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_History_User");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Log__5E5499A8BFF1F0C3");

            entity.ToTable("Log");

            entity.Property(e => e.LogId)
                .HasMaxLength(50)
                .HasColumnName("LogID");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.ScheduleId)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("ScheduleID");
            entity.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("UserID");

            entity.HasOne(d => d.Schedule).WithMany(p => p.Logs)
                .HasForeignKey(d => d.ScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Log_Schedule");

            entity.HasOne(d => d.User).WithMany(p => p.Logs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Log_User");
        });

        modelBuilder.Entity<MetroLine>(entity =>
        {
            entity.HasKey(e => e.LineId).HasName("PK__MetroLin__2EAE64C95C08D947");

            entity.ToTable("MetroLine");

            entity.Property(e => e.LineId)
                .HasMaxLength(50)
                .HasColumnName("LineID");
            entity.Property(e => e.LineName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<MetroStation>(entity =>
        {
            entity.HasKey(e => e.StationId).HasName("PK__MetroSta__E0D8A6DD6DDCB427");

            entity.ToTable("MetroStation");

            entity.Property(e => e.StationId)
                .HasMaxLength(50)
                .HasColumnName("StationID");
            entity.Property(e => e.LineId)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("LineID");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.StationName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.Latitude)
      .HasColumnType("FLOAT")
      .HasColumnName("Latitude");

            entity.Property(e => e.Longitude)
                .HasColumnType("FLOAT")
                .HasColumnName("Longitude");
            entity.HasOne(d => d.Line).WithMany(p => p.MetroStations)
                .HasForeignKey(d => d.LineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Line");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3A5FC37FD0");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .HasMaxLength(50)
                .HasColumnName("RoleID");
            entity.Property(e => e.RoleName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__9C8A5B69E88DF52B");

            entity.ToTable("Schedule");

            entity.Property(e => e.ScheduleId)
                .HasMaxLength(50)
                .HasColumnName("ScheduleID");
            entity.Property(e => e.LineId)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("LineID");
            entity.Property(e => e.StationId)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("StationID");

            entity.HasOne(d => d.Line).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.LineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedule_Line");

            entity.HasOne(d => d.Station).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.StationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedule_Station");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCACA0386BDA");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D105345964423E").IsUnique();

            entity.HasIndex(e => e.FirebaseUid, "UQ__User__F82B22B24CAA9900").IsUnique();

            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("UserID");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.FirebaseUid).HasMaxLength(255);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.RoleId)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("RoleID");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}