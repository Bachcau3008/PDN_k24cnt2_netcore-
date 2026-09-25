using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PdnFirstDatabase.Models;

public partial class PdnLesson10EfdbContext : DbContext
{
    public PdnLesson10EfdbContext()
    {
    }

    public PdnLesson10EfdbContext(DbContextOptions<PdnLesson10EfdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PdnUser> PdnUsers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=PdnLesson10EFDb;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PdnUser>(entity =>
        {
            entity.HasKey(e => e.PdnId).HasName("PK__PdnUser__97996EECF392AB03");

            entity.ToTable("PdnUser");

            entity.Property(e => e.PdnEmail).HasMaxLength(100);
            entity.Property(e => e.PdnFullName).HasMaxLength(100);
            entity.Property(e => e.PdnPassword).HasMaxLength(255);
            entity.Property(e => e.PdnPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PdnUsername).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
