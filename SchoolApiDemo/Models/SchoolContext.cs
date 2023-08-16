using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolApiDemo.Models;

public partial class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Class { get; set; }

    public virtual DbSet<Score> Score { get; set; }

    public virtual DbSet<Student> Student { get; set; }

    public virtual DbSet<Teacher> Teacher { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.Property(e => e.ClassName).IsUnicode(false);
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity.Property(e => e.StudentScore).IsUnicode(false);

            entity.HasOne(d => d.Class).WithMany(p => p.Score)
                .HasForeignKey(d => d.ClassID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Score_ToClass");

            entity.HasOne(d => d.Student).WithMany(p => p.Score)
                .HasForeignKey(d => d.StudentID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Score_ToStudent");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.Property(e => e.TeacherName).IsUnicode(false);
            entity.Property(e => e.TeacherSex).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
