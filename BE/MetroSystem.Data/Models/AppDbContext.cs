using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MetroSystem.Data.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-IQK16CS\\QUANGZY;Database=MetroSystem;User Id=sa;Password=12345;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bookmark>(entity =>
        {
            entity.HasKey(e => e.BookmarkId).HasName("PK__Bookmark__541A3A91C3D6FBE4");

            entity.ToTable("Bookmark");

            entity.Property(e => e.BookmarkId).HasColumnName("BookmarkID");
            entity.Property(e => e.LineId).HasColumnName("LineID");
            entity.Property(e => e.StationId).HasColumnName("StationID");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.UserId).HasColumnName("UserID");

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
            entity.HasKey(e => e.BusLineId).HasName("PK__BusLine__0FF2C3D3362E5429");

            entity.ToTable("BusLine");

            entity.Property(e => e.BusLineId).HasColumnName("BusLineID");
            entity.Property(e => e.BusLineName).HasMaxLength(100);
            entity.Property(e => e.Route).HasMaxLength(255);
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<BusSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__BusSched__9C8A5B69218E7CFC");

            entity.ToTable("BusSchedule");

            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
            entity.Property(e => e.BusLineId).HasColumnName("BusLineID");
            entity.Property(e => e.BusStationId).HasColumnName("BusStationID");
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
            entity.HasKey(e => e.BusStationId).HasName("PK__BusStati__BF771EE450EE93E5");

            entity.ToTable("BusStation");

            entity.Property(e => e.BusStationId).HasColumnName("BusStationID");
            entity.Property(e => e.BusStationName).HasMaxLength(100);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<BusStationMetroStation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BusStati__3214EC272D378005");

            entity.ToTable("BusStation_MetroStation");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BusStationId).HasColumnName("BusStationID");
            entity.Property(e => e.MetroStationId).HasColumnName("MetroStationID");

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
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF679A236E0");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.Comment).HasMaxLength(1000);
            entity.Property(e => e.LineId).HasColumnName("LineID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

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
            entity.HasKey(e => e.HistoryId).HasName("PK__History__4D7B4ADDE4B17E90");

            entity.ToTable("History");

            entity.Property(e => e.HistoryId).HasColumnName("HistoryID");
            entity.Property(e => e.Message).HasMaxLength(1000);
            entity.Property(e => e.RecommendId).HasColumnName("RecommendID");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Histories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_History_User");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Log__5E5499A8AC4B6D85");

            entity.ToTable("Log");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

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
            entity.HasKey(e => e.LineId).HasName("PK__MetroLin__2EAE64C935F54A07");

            entity.ToTable("MetroLine");

            entity.Property(e => e.LineId).HasColumnName("LineID");
            entity.Property(e => e.LineName).HasMaxLength(100);
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<MetroStation>(entity =>
        {
            entity.HasKey(e => e.StationId).HasName("PK__MetroSta__E0D8A6DD6B7D41A0");

            entity.ToTable("MetroStation");

            entity.Property(e => e.StationId).HasColumnName("StationID");
            entity.Property(e => e.LineId).HasColumnName("LineID");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.StationName).HasMaxLength(100);
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.Line).WithMany(p => p.MetroStations)
                .HasForeignKey(d => d.LineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Station_Line");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3A8C3ECF34");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__9C8A5B695FCDEF13");

            entity.ToTable("Schedule");

            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
            entity.Property(e => e.LineId).HasColumnName("LineID");
            entity.Property(e => e.StationId).HasColumnName("StationID");

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
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC63EEAA71");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D105340B05B711").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
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
