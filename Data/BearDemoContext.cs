using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace bear_project_server.Data;

public partial class BearDemoContext : DbContext
{
    public BearDemoContext()
    {
    }

    public BearDemoContext(DbContextOptions<BearDemoContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Report>? Reports { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Report>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Encounter)
                .HasMaxLength(1000)
                .IsFixedLength();
            entity.Property(e => e.Location)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("Date('now')")
                .HasColumnName("TImeStamp");
            entity.Property(e => e.Type)
                .HasMaxLength(40)
                .IsFixedLength();
            entity.Property(e => e.lat)
                .HasPrecision(8,6)
                .IsFixedLength();
            entity.Property(e => e.lng)
                .HasPrecision(9,6)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
