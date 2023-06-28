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
    }

    public virtual DbSet<Report>? Reports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MOASDBDEV50\\SMALLAPPS;Database=BearDemo;Integrated Security=True;Encrypt = False ");

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
                .HasDefaultValueSql("(getdate())")
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
