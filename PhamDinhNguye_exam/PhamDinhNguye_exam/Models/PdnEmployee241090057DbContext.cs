using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PhamDinhNguye_exam.Models;

public partial class PdnEmployee241090057DbContext : DbContext
{
    public PdnEmployee241090057DbContext()
    {
    }

    public PdnEmployee241090057DbContext(DbContextOptions<PdnEmployee241090057DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PdnEmployee> PdnEmployees { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=PdnEmployee_241090057_Db;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PdnEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PdnEmplo__3214EC075C5351F5");

            entity.ToTable("PdnEmployee");

            entity.HasIndex(e => e.PdnEmail, "UQ__PdnEmplo__747A4F94E8278DA7").IsUnique();

            entity.Property(e => e.PdnActive).HasDefaultValue(true);
            entity.Property(e => e.PdnEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PdnGender).HasMaxLength(10);
            entity.Property(e => e.PdnName).HasMaxLength(100);
            entity.Property(e => e.PdnPhone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
