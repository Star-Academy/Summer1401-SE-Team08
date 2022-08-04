﻿namespace EFCore.Database;

using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using EFCore.Entity;

public class StudentDatabase : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Grade> Grades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Database=StudentDatabase;Username=postgres;Password=Khosro1381");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasKey(s => s.StudentNumber);
        modelBuilder.Entity<Grade>().HasKey(g => new {g.StudentNumber, g.Lesson});
        modelBuilder.Entity<Grade>().HasOne<Student>().WithMany().HasForeignKey(s => s.StudentNumber);
    }
}